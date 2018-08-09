//using System.Web.Compilation;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DXApplication9.ReportesSistema
{
    #region "Extensiones al DataContext"

    public static class DataContextExtensions
    {
        public static ITable GetTableByName(this DataContext context, string tableName)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (tableName == null)
            {
                throw new ArgumentNullException("tableName");
            }
            return (ITable)context.GetType().GetProperty(tableName).GetValue(context, null);
        }

        public static MemberInfo GetTableMemberInfo(this Type contextType, string tableName)
        {
            if (String.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            var members = contextType.FindMembers(MemberTypes.Field | MemberTypes.Property,
                                                           BindingFlags.Public | BindingFlags.Instance |
                                                           BindingFlags.Static, /*filter*/null, /*filterCriteria*/null);

            return members.FirstOrDefault(t => String.Equals(t.Name, tableName, StringComparison.OrdinalIgnoreCase));
        }

        public static object GetIntancedTableByName(this Type contextType, string tableName)
        {
            var tableMemberInfo = contextType.GetTableMemberInfo(tableName);
            // fetch the table from the context.
            if (tableMemberInfo != null)
            {
                var field = tableMemberInfo as FieldInfo;
                if (field != null)
                {
                    return field.GetValue(contextType);
                }

                var property = tableMemberInfo as PropertyInfo;
                if (property != null)
                {
                    return property.GetValue(contextType, null);
                }
            }

            return null;
        }
    }

    #endregion

    #region "Extensiones a Table"

    public static class TableExtensions
    {
        /// <summary>
        /// Obtiene el Nombre real de la Base de Datos a partir del Nombre Mapeado en el Datacontext
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="mappingTable"></param>
        /// <returns></returns>
        public static string GetRealTableName(this Type entityType, string mappingTable)
        {
            var model = new AttributeMappingSource().GetModel(entityType);
            var tableName = model.GetTables().Single(t => t.RowType.Name == mappingTable).TableName;
            return tableName.Replace("dbo.", "");
        }

        public static string GetRealTableName<TEntity>(this Table<TEntity> myTable) where TEntity : class
        {
            var type = typeof(TEntity);

            var temp = type.GetCustomAttributes(typeof(TableAttribute), true);

            return temp.Length == 0 ? null : (temp[0] as TableAttribute).Name.Replace("dbo.", "");
        }


        /// <summary>
        /// Obtiene el Nombre real de la Tabla Mapeada a partir de la instancia de la Clase del DataContext
        /// </summary>
        /// <param name="entity">Instancia de la Clase </param>
        /// <returns></returns>
        public static string GetRealTableName(this object entity)
        {
            var type = entity.GetType();

            var temp = type.GetCustomAttributes(typeof(TableAttribute), true);

            return temp.Length == 0 ? type.Name : (temp[0] as TableAttribute).Name.Replace("dbo.", "");
        }

        /// <summary>
        /// Obtiene el objeto de la propiedad que es la clave primaria
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static PropertyInfo GetPrimaryKey(this Type entityType)
        {
            return (from info in entityType.GetProperties()
                    let attr = info.GetCustomAttributes(typeof(ColumnAttribute), false).FirstOrDefault(x => ((ColumnAttribute)x).IsPrimaryKey && ((ColumnAttribute)x).DbType.Contains("NOT NULL"))
                    where attr != null
                    select info).FirstOrDefault();
        }

        /// <summary>
        /// Obtiene en nombre del Campo Primario
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static string GetPrimaryKeyName(this Type entityType)
        {
            foreach (var info in from info in entityType.GetProperties()
                                 let
                                     attr = info.GetCustomAttributes(typeof(ColumnAttribute), false).FirstOrDefault(x => ((ColumnAttribute)x).IsPrimaryKey && ((ColumnAttribute)x).DbType.Contains("NOT NULL"))
                                 where attr != null
                                 select info)
            {
                return info.Name;
            }
            return String.Empty;
        }

        /// <summary>
        /// Obtiene la lista de Propiedades del tipo columna (Los campos de una tabla)
        /// </summary>
        /// <param name="entityType">Objeto del tipo Table</param>
        /// <param name="includePrimaryKey">Incluir en la lista de campos el Campo Llave?</param>
        /// <param name="includeAllowNullField">Incluir los campos que permiten valores nulos?</param>
        /// <returns></returns>
        public static List<string> GetFieldList(this Type entityType, bool includePrimaryKey, bool includeAllowNullField)
        {
            var list = new List<string>();
            foreach (var col in entityType.GetProperties())
            {
                //Columns
                var columns = col.GetCustomAttributes(typeof(ColumnAttribute), false).FirstOrDefault(x => ((((ColumnAttribute)x).IsPrimaryKey && includePrimaryKey) || !((ColumnAttribute)x).IsPrimaryKey) && (includeAllowNullField || ((ColumnAttribute)x).DbType.Contains("NOT NULL")));
                if (columns != null) list.Add(col.Name);
                //Associations
                var associations = col.GetCustomAttributes(typeof(AssociationAttribute), false).FirstOrDefault(x => ((AssociationAttribute)x).IsForeignKey);
                if (associations != null) list.Add(col.Name);
            }
            return list;
        }
    }

    #endregion

    #region "Extensiones a Object"

    public static class ObjectExtensions
    {
        /// <summary>
        /// Investiga si el Hijo tiene una relación con el Padre donde la regla de borrado sea en cascada
        /// Es decir, Si el Padre borra el hijo en Cascada (en SQL) cuando se borra un artúculo de él.
        /// Para esto se busca la DeleteRule == "CASCADE" en los atributos de la relación (AssociationAttribute)
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="padre"></param>
        /// <returns></returns>
        public static bool SeBorraEnCascadaCon(this Type hijo, Type padre)
        {
            return hijo.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Any(p => p.PropertyType.Name == padre.Name
                                && p.GetCustomAttributes(typeof(AssociationAttribute), true).Any()
                                && ((AssociationAttribute)p.GetCustomAttributes(typeof(AssociationAttribute), true)[0]).DeleteRule == "CASCADE");
        }

        //Obtiene el Objeto (Tipo) correspondiente al Nombre de la clase
        //Debe venir de la forma Ensamblado.Directorio.Clase
        //Ej.: Zeus.Comun.DataContext.ENTArea
        //public static Type GetTypeFromFullName(this string objectName)
        //{
        //    return BuildManager.GetType(objectName, /*throwOnFail*/false, /*ignoreCase*/true);
        //}

        public static object CreateObjectInstance(this Type type, params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        public static object GetFieldValue(this object source, string field)
        {
            if (source == null) throw new ArgumentNullException("source");

            var fields = field.Split('.');

            if (fields.Count() == 1) return source.GetType().GetProperty(field) == null ? null : source.GetType().GetProperty(field).GetValue(source, null);
            //Viene un Campo del Tipo Campo.Campo, ejemplo: ENTArea.ENTAreaClasificacion.CuentaGastoID 
            //y tengo que llamar recursivo a este método para obtener el último valor
            var value = fields.Aggregate(source, (current, s) => current.GetFieldValue(s));

            return value;
        }

        public static void SetFieldValue(this object source, string field, object newValue)
        {
            if (source == null) throw new ArgumentNullException("source");

            PropertyInfo propertyInfo = source.GetType().GetProperty(field);
            propertyInfo.SetValue(source, newValue, null);

        }
    }

    #endregion

    #region "Extensiones al IEnumerable"

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (T el in list)
            {
                yield return el;
                if (predicate(el))
                    yield break;
            }
        }
    }

    #endregion

    #region "Extensiones al IQueryable"
    /// <summary>
    /// Clase incluida en los ejemplos de la SDK de LINQ para generar consultas dinámicas con LINQ
    /// Patch for Solar code
    /// </summary>
    public static class DynamicQueryable
    {
        public static IQueryable OfType(this IQueryable source, string typeStr)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (typeStr == null) throw new ArgumentNullException("typeStr");

            Type type = Assembly.GetExecutingAssembly().GetType(typeStr);
            MethodInfo methodOfType = typeof(Queryable).GetMethods().First(m => m.Name == "OfType" && m.IsGenericMethod);

            return source.Provider.CreateQuery(Expression.Call(null, methodOfType.MakeGenericMethod(new Type[] { type }), new Expression[] { source.Expression }));
        }

        /// <summary>
        /// Transforma un IQueryable genérico en un IQueryable tipado. Similar a "Cast"
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<TResult> Transform<TResult>(this IQueryable source)
        {
            var resultType = typeof(TResult);
            var resultProperties = resultType.GetProperties().Where(p => p.CanWrite);

            ParameterExpression s = Expression.Parameter(source.ElementType, "s");

            var memberBindings =
                resultProperties.Select(p =>
                                        Expression.Bind(typeof(TResult).GetMember(p.Name)[0], Expression.Property(s, p.Name))).OfType<MemberBinding>();

            Expression memberInit = Expression.MemberInit(
                Expression.New(typeof(TResult)),
                memberBindings
                );

            var memberInitLambda = Expression.Lambda(memberInit, s);

            var typeArgs = new[]
                               {
                                   source.ElementType, 
                                   memberInit.Type
                               };

            var mc = Expression.Call(typeof(Queryable), "Select", typeArgs, source.Expression, memberInitLambda);

            var query = source.Provider.CreateQuery<TResult>(mc);

            return query;
        }

        /// <summary>
        /// Transforma un IEnumerable genérico en un IEnumerable tipado. Similar a "Cast"
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Transform<TResult>(this IEnumerable source)
        {
            return source.AsQueryable().Transform<TResult>();
        }

        public static IQueryable Query(this IQueryable source, String func, params Object[] values)
        {
            return Execute<IQueryable>(source, func, values);
        }

        public static T Execute<T>(this IQueryable source, String func, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            return DynamicExpression.ParseLambda<IQueryable, T>(func, values).Compile()(source);
        }

        public static void Run(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            source.Cast<Object>().ToArray();
        }

        public static Object Aggregate(this IQueryable source, String func, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(new ParameterExpression[]
                                                                        {
                                                                            Expression.Parameter(source.ElementType, "a")
                                                                            ,
                                                                            Expression.Parameter(source.ElementType, "e")
                                                                            ,
                                                                        }, null, func, values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Aggregate",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Boolean Any(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<Boolean>(
                Expression.Call(
                    typeof(Queryable), "Any",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Boolean Any(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<Boolean>(
                Expression.Call(
                    typeof(Queryable), "Any",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Boolean All(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<Boolean>(
                Expression.Call(
                    typeof(Queryable), "All",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Boolean All(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<Boolean>(
                Expression.Call(
                    typeof(Queryable), "All",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        // Average

        // Cast<TResult>()

        public static IQueryable Concat(this IQueryable first, IEnumerable second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            return first.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Concat",
                    new Type[] { first.ElementType, },
                    first.Expression, Expression.Constant(second)
                    )
                );
        }

        public static Boolean Contains(this IQueryable source, Object item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            return source.Provider.Execute<Boolean>(
                Expression.Call(
                    typeof(Queryable), "Contains",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(item)
                    )
                );

        }

        public static Int32 Count(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<Int32>(
                Expression.Call(
                    typeof(Queryable), "Count",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Int32 Count(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<Int32>(
                Expression.Call(
                    typeof(Queryable), "Count",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable DefaultIfEmpty(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "DefaultIfEmpty",
                    new Type[] { source.ElementType, },
                    source.Expression
                    )
                );
        }

        public static IQueryable DefaultIfEmpty(this IQueryable source, Object defaultValue)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "DefaultIfEmpty",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(defaultValue)
                    )
                );
        }

        public static IQueryable Distinct(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Distinct",
                    new Type[] { source.ElementType, },
                    source.Expression
                    )
                );
        }

        public static Object ElementAt(this IQueryable source, Int32 index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "ElementAt",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(index)
                    )
                );
        }

        public static T ElementAt<T>(this IQueryable<T> source, Int32 index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "ElementAt",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(index)
                    )
                );
        }

        public static Object ElementAtOrDefault(this IQueryable source, Int32 index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "ElementAtOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(index)
                    )
                );
        }

        public static T ElementAtOrDefault<T>(this IQueryable<T> source, Int32 index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "ElementAtOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Constant(index)
                    )
                );
        }

        public static IQueryable Except(this IQueryable source1, IEnumerable source2)
        {
            if (source1 == null)
            {
                throw new ArgumentNullException("source1");
            }
            if (source2 == null)
            {
                throw new ArgumentNullException("source2");
            }
            return source1.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Except",
                    new Type[] { source1.ElementType, },
                    source1.Expression, Expression.Constant(source2)
                    )
                );
        }

        public static Object First(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "First",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object First(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "First",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T First<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "First",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static T First<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "First",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Object FirstOrDefault(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "FirstOrDefault",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static T FirstOrDefault<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "FirstOrDefault",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object FirstOrDefault(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "FirstOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T FirstOrDefault<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "FirstOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable GroupBy(this IQueryable source, String keySelector, String elementSelector,
                                         params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            if (elementSelector == null)
            {
                throw new ArgumentNullException("elementSelector");
            }
            LambdaExpression keyLambda = DynamicExpression.ParseLambda(source.ElementType, null, keySelector, values);
            LambdaExpression elementLambda = DynamicExpression.ParseLambda(source.ElementType, null, elementSelector,
                                                                           values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "GroupBy",
                    new Type[] { source.ElementType, keyLambda.Body.Type, elementLambda.Body.Type, },
                    source.Expression, Expression.Quote(keyLambda), Expression.Quote(elementLambda)
                    )
                );
        }

        // GroupJoin

        public static IQueryable Intersect(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Intersect",
                    new Type[] { source.ElementType, },
                    source.Expression
                    )
                );
        }

        // Join

        public static Object Last(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Last",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static T Last<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "Last",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object Last(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Last",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T Last<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "Last",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Object LastOrDefault(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "LastOrDefault",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static T LastOrDefault<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "LastOrDefault",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object LastOrDefault(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "LastOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T LastOrDefault<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "LastOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Int64 LongCount(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<Int64>(
                Expression.Call(
                    typeof(Queryable), "LongCount",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Int64 LongCount(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<Int64>(
                Expression.Call(
                    typeof(Queryable), "LongCount",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Object Max(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Max",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object Max(this IQueryable source, String selector, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Max",
                    new Type[] { source.ElementType, lambda.ReturnType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static Object Min(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Min",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object Min(this IQueryable source, String selector, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Min",
                    new Type[] { source.ElementType, lambda.ReturnType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        // OfType

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, String ordering, params Object[] values)
        {
            return (IQueryable<T>)OrderBy((IQueryable)source, ordering, values);
        }

        public static IQueryable OrderBy(this IQueryable source, String ordering, params Object[] values)
        {
            if (ordering == string.Empty)
                return source;

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (ordering == null)
            {
                throw new ArgumentNullException("ordering");
            }
            ParameterExpression[] parameters = new ParameterExpression[]
                                                   {
                                                       Expression.Parameter(source.ElementType, ""),
                                                   };
            ExpressionParser parser = new ExpressionParser(parameters, ordering, values);
            IEnumerable<DynamicOrdering> orderings = parser.ParseOrdering();
            Expression queryExpr = source.Expression;
            String methodAsc = "OrderBy";
            String methodDesc = "OrderByDescending";
            foreach (DynamicOrdering o in orderings)
            {
                queryExpr = Expression.Call(
                    typeof(Queryable), o.Ascending ? methodAsc : methodDesc,
                    new Type[] { source.ElementType, o.Selector.Type, },
                    queryExpr, Expression.Quote(Expression.Lambda(o.Selector, parameters))
                    );
                methodAsc = "ThenBy";
                methodDesc = "ThenByDescending";
            }
            return source.Provider.CreateQuery(queryExpr);
        }

        public static IQueryable Reverse(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Reverse",
                    new Type[] { source.ElementType, },
                    source.Expression
                    )
                );
        }

        public static IQueryable Select(this IQueryable source, String selector, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Select",
                    new Type[] { source.ElementType, lambda.Body.Type, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable<T> Select<T>(this IQueryable source, String selector, params Object[] values)
        {
            return Select(source, selector, values).Cast<T>();
        }

        public static IQueryable SelectMany(this IQueryable source, String selector, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, null, selector, values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "SelectMany",
                    new Type[] { source.ElementType, lambda.Body.Type, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable SequenceEqual(this IQueryable source1, IEnumerable source2)
        {
            if (source1 == null)
            {
                throw new ArgumentNullException("source1");
            }
            if (source2 == null)
            {
                throw new ArgumentNullException("source2");
            }
            return source1.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "SequenceEqual",
                    new Type[] { source1.ElementType, },
                    source1.Expression, Expression.Constant(source2)
                    )
                );
        }

        public static Object Single(this IQueryable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Single",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static T Single<T>(this IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "Single",
                    new Type[] { source.ElementType, }, source.Expression
                    )
                );
        }

        public static Object Single(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "Single",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T Single<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "Single",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        //public static Object SingleOrDefault(this IQueryable source)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.Execute(
        //        Expression.Call(
        //            typeof (Queryable), "SingleOrDefault",
        //            new Type[] {source.ElementType,}, source.Expression
        //            )
        //        );
        //}

        //public static T SingleOrDefault<T>(this IQueryable<T> source)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.Execute<T>(
        //        Expression.Call(
        //            typeof (Queryable), "SingleOrDefault",
        //            new Type[] {source.ElementType,}, source.Expression
        //            )
        //        );
        //}

        public static Object SingleOrDefault(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute(
                Expression.Call(
                    typeof(Queryable), "SingleOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static T SingleOrDefault<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.Execute<T>(
                Expression.Call(
                    typeof(Queryable), "SingleOrDefault",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        //public static IQueryable Skip(this IQueryable source, Int32 count)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.CreateQuery(
        //        Expression.Call(
        //            typeof(Queryable), "Skip",
        //            new Type[] { source.ElementType, },
        //            source.Expression, Expression.Constant(count)
        //            )
        //        );
        //}

        //public static IQueryable<T> Skip<T>(this IQueryable<T> source, Int32 count)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.CreateQuery<T>(
        //        Expression.Call(
        //            typeof(Queryable), "Skip",
        //            new Type[] { source.ElementType, },
        //            source.Expression, Expression.Constant(count)
        //            )
        //        );
        //}

        public static IQueryable SkipWhile(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "SkipWhile",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable<T> SkipWhile<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.CreateQuery<T>(
                Expression.Call(
                    typeof(Queryable), "SkipWhile",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        // Sum

        public static object Sum(this IQueryable source, string member)
        {

            if (source == null) throw new ArgumentNullException("source");
            if (member == null) throw new ArgumentNullException("member");

            PropertyInfo prop = source.ElementType.GetProperty(member);

            ParameterExpression param = Expression.Parameter(source.ElementType, "s");

            Expression selector = Expression.Lambda(Expression.MakeMemberAccess(param, prop), param);

            MethodInfo sumMethod = typeof(Queryable).GetMethods().First(m => m.Name == "Sum" && m.ReturnType == prop.PropertyType && m.IsGenericMethod);

            return source.Provider.Execute(Expression.Call(null, sumMethod.MakeGenericMethod(new Type[] { source.ElementType }), new Expression[] { source.Expression, Expression.Quote(selector) }));

        }

        public static object Sum<TSource>(this IQueryable<TSource> source, string member)
        {

            if (source == null) throw new ArgumentNullException("source");
            if (member == null) throw new ArgumentNullException("member");

            PropertyInfo prop = typeof(TSource).GetProperty(member);

            ParameterExpression param = Expression.Parameter(typeof(TSource), "s");

            Expression selector = Expression.Lambda(Expression.MakeMemberAccess(param, prop), param);

            MethodInfo sumMethod = typeof(Queryable).GetMethods().First(m => m.Name == "Sum" && m.ReturnType == prop.PropertyType && m.IsGenericMethod);

            return source.Provider.Execute(Expression.Call(null, sumMethod.MakeGenericMethod(new Type[] { typeof(TSource) }), new Expression[] { source.Expression, Expression.Quote(selector) }));
        }

        //public static IQueryable Take(this IQueryable source, Int32 count)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.CreateQuery(
        //        Expression.Call(
        //            typeof(Queryable), "Take",
        //            new Type[] { source.ElementType, },
        //            source.Expression, Expression.Constant(count)
        //            )
        //        );
        //}

        //public static IQueryable<T> Take<T>(this IQueryable<T> source, Int32 count)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    return source.Provider.CreateQuery<T>(
        //        Expression.Call(
        //            typeof(Queryable), "Take",
        //            new Type[] { source.ElementType, },
        //            source.Expression, Expression.Constant(count)
        //            )
        //        );
        //}

        public static IQueryable TakeWhile(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "TakeWhile",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable<T> TakeWhile<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.CreateQuery<T>(
                Expression.Call(
                    typeof(Queryable), "TakeWhile",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable Union(this IQueryable source1, IEnumerable source2)
        {
            if (source1 == null)
            {
                throw new ArgumentNullException("source1");
            }
            if (source2 == null)
            {
                throw new ArgumentNullException("source2");
            }
            return source1.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Union",
                    new Type[] { source1.ElementType, },
                    source1.Expression, Expression.Constant(source2)
                    )
                );
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, String predicate, params Object[] values)
        {
            return (IQueryable<T>)Where((IQueryable)source, predicate, values);
        }

        public static IQueryable Where(this IQueryable source, String predicate, params Object[] values)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            LambdaExpression lambda = DynamicExpression.ParseLambda(source.ElementType, typeof(Boolean), predicate,
                                                                    values);
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Where",
                    new Type[] { source.ElementType, },
                    source.Expression, Expression.Quote(lambda)
                    )
                );
        }

        public static IQueryable Zip(this IQueryable source1, IEnumerable source2, String selector,
                                     params Object[] values)
        {
            if (source1 == null)
            {
                throw new ArgumentNullException("source1");
            }
            if (source2 == null)
            {
                throw new ArgumentNullException("source2");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            Type source2ElementType = source2.GetType().GetInterface("IEnumerable`1").GetGenericArguments().Single();
            LambdaExpression lambda = DynamicExpression.ParseLambda(new ParameterExpression[]
                                                                        {
                                                                            Expression.Parameter(source1.ElementType,
                                                                                                 "x"),
                                                                            Expression.Parameter(source2ElementType, "y")
                                                                            ,
                                                                        }, null, selector, values);
            return source1.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "Zip",
                    new Type[] { source1.ElementType, source2ElementType, lambda.ReturnType, },
                    source1.Expression, Expression.Constant(source2), Expression.Quote(lambda)
                    )
                );
        }
    }


   public static partial class MoreEnumerable
    {
        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the default eqaulity comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }

        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <param name="comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");
            return DistinctByImpl(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
#if !NO_HASHSET
            var knownKeys = new HashSet<TKey>(comparer);
            foreach (var element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
#else
            //
            // On platforms where LINQ is available but no HashSet<T>
            // (like on Silverlight), implement this operator using 
            // existing LINQ operators. Using GroupBy is slightly less
            // efficient since it has do all the grouping work before
            // it can start to yield any one element from the source.
            //

            return source.GroupBy(keySelector, comparer).Select(g => g.First());
#endif
        }
    }

    #endregion

    #region "Clase DynamicClass"

    public abstract class DynamicClass
    {
        public override String ToString()
        {
            var props = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var sb = new StringBuilder();
            sb.Append("{");
            for (var i = 0; i < props.Length; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append(props[i].Name);
                sb.Append("=");
                sb.Append(props[i].GetValue(this, null));
            }
            sb.Append("}");
            return sb.ToString();
        }
    }

    #endregion

    #region "Clase DynamicProperty"

    public class DynamicProperty
    {
        public String Name { get; private set; }

        public Type Type { get; private set; }

        public DynamicProperty(String name, Type type)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            this.Name = name;
            this.Type = type;
        }
    }

    #endregion

    #region "Clase DynamicExpression"

    public static class DynamicExpression
    {
        public static Expression Parse(Type resultType, String expression, params Object[] values)
        {
            return new ExpressionParser(null, expression, values).Parse(resultType);
        }

        public static LambdaExpression ParseLambda(Type resultType, String expression, params Object[] values)
        {
            return ParseLambda(new ParameterExpression[0], resultType, expression, values);
        }

        public static LambdaExpression ParseLambda(Type itType, Type resultType, String expression,
                                                   params Object[] values)
        {
            return ParseLambda(new[] { Expression.Parameter(itType, ""), }, resultType, expression, values);
        }

        public static LambdaExpression ParseLambda(ParameterExpression[] parameters, Type resultType, String expression,
                                                   params Object[] values)
        {
            return Expression.Lambda(new ExpressionParser(parameters, expression, values).Parse(resultType), parameters);
        }

        public static Expression<Func<TReturn>> ParseLambda<TReturn>(String expression, params Object[] values)
        {
            return (Expression<Func<TReturn>>)ParseLambda(typeof(TReturn), expression, values);
        }

        public static Expression<Func<T, TReturn>> ParseLambda<T, TReturn>(String expression, params Object[] values)
        {
            return (Expression<Func<T, TReturn>>)ParseLambda(typeof(T), typeof(TReturn), expression, values);
        }

        public static Type CreateClass(params DynamicProperty[] properties)
        {
            return ClassFactory.Instance.GetDynamicClass(properties);
        }

        public static Type CreateClass(IEnumerable<DynamicProperty> properties)
        {
            return ClassFactory.Instance.GetDynamicClass(properties);
        }
    }

    #endregion

    #region "Clase DynamicOrdering"

    internal class DynamicOrdering
    {
        public Expression Selector;
        public Boolean Ascending;
    }

    #endregion

    #region "Clase Signature"

    internal class Signature
        : IEquatable<Signature>
    {
        private readonly Int32 AHashCode;

        public DynamicProperty[] Properties { get; private set; }

        public Signature(IEnumerable<DynamicProperty> properties)
        {
            this.Properties = properties.ToArray();
            this.AHashCode = 0;
            foreach (DynamicProperty p in properties)
            {
                this.AHashCode ^= p.Name.GetHashCode() ^ p.Type.GetHashCode();
            }
        }

        public override Int32 GetHashCode()
        {
            return this.AHashCode;
        }

        public override Boolean Equals(Object obj)
        {
            return obj is Signature ? this.Equals((Signature)obj) : false;
        }

        public Boolean Equals(Signature other)
        {
            return this.Properties.Length == other.Properties.Length && !this.Properties
                                                                             .Where(
                                                                                 (t, i) =>
                                                                                 t.Name != other.Properties[i].Name ||
                                                                                 t.Type != other.Properties[i].Type)
                                                                             .Any();
        }
    }

    #endregion

    #region "Clase ClassFactory"

    internal class ClassFactory
    {
        public static readonly ClassFactory Instance = new ClassFactory();

        static ClassFactory()
        {
            // Trigger lazy initialization of static fields
        }

        private readonly ModuleBuilder AModule;
        private readonly Dictionary<Signature, Type> AClasses;
        private Int32 AClassCount;
        private readonly ReaderWriterLock ARwLock;

        private ClassFactory()
        {
            AssemblyName name = new AssemblyName("DynamicClasses");
            AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            this.AModule = assembly.DefineDynamicModule("Module");
            this.AClasses = new Dictionary<Signature, Type>();
            this.ARwLock = new ReaderWriterLock();
        }

        public Type GetDynamicClass(IEnumerable<DynamicProperty> properties)
        {
            this.ARwLock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                Signature signature = new Signature(properties);
                Type type;
                if (!this.AClasses.TryGetValue(signature, out type))
                {
                    type = this.CreateDynamicClass(signature.Properties);
                    this.AClasses.Add(signature, type);
                }
                return type;
            }
            finally
            {
                this.ARwLock.ReleaseReaderLock();
            }
        }

        private Type CreateDynamicClass(IEnumerable<DynamicProperty> properties)
        {
            LockCookie cookie = this.ARwLock.UpgradeToWriterLock(Timeout.Infinite);
            try
            {
                String typeName = "DynamicClass" + (this.AClassCount + 1);
                TypeBuilder tb = this.AModule.DefineType(typeName, TypeAttributes.Class |
                                                                  TypeAttributes.Public, typeof(DynamicClass));
                IEnumerable<FieldInfo> fields = GenerateProperties(tb, properties);
                GenerateEquals(tb, fields);
                GenerateGetHashCode(tb, fields);
                Type result = tb.CreateType();
                ++this.AClassCount;
                return result;
            }
            finally
            {
                this.ARwLock.DowngradeFromWriterLock(ref cookie);
            }
        }

        private static IEnumerable<FieldInfo> GenerateProperties(TypeBuilder tb, IEnumerable<DynamicProperty> properties)
        {
            foreach (DynamicProperty dp in properties)
            {
                FieldBuilder fb = tb.DefineField("_" + dp.Name, dp.Type, FieldAttributes.Private);
                PropertyBuilder pb = tb.DefineProperty(dp.Name, PropertyAttributes.HasDefault, dp.Type, null);
                MethodBuilder mbGet = tb.DefineMethod("get_" + dp.Name,
                                                      MethodAttributes.Public | MethodAttributes.SpecialName |
                                                      MethodAttributes.HideBySig,
                                                      dp.Type, Type.EmptyTypes);
                ILGenerator genGet = mbGet.GetILGenerator();
                genGet.Emit(OpCodes.Ldarg_0);
                genGet.Emit(OpCodes.Ldfld, fb);
                genGet.Emit(OpCodes.Ret);
                MethodBuilder mbSet = tb.DefineMethod("set_" + dp.Name,
                                                      MethodAttributes.Public | MethodAttributes.SpecialName |
                                                      MethodAttributes.HideBySig,
                                                      null, new Type[] { dp.Type, });
                ILGenerator genSet = mbSet.GetILGenerator();
                genSet.Emit(OpCodes.Ldarg_0);
                genSet.Emit(OpCodes.Ldarg_1);
                genSet.Emit(OpCodes.Stfld, fb);
                genSet.Emit(OpCodes.Ret);
                pb.SetGetMethod(mbGet);
                pb.SetSetMethod(mbSet);
                yield return fb;
            }
        }

        private static void GenerateEquals(TypeBuilder tb, IEnumerable<FieldInfo> fields)
        {
            MethodBuilder mb = tb.DefineMethod("Equals",
                                               MethodAttributes.Public | MethodAttributes.ReuseSlot |
                                               MethodAttributes.Virtual | MethodAttributes.HideBySig,
                                               typeof(Boolean), new Type[] { typeof(Object), });
            ILGenerator gen = mb.GetILGenerator();
            LocalBuilder other = gen.DeclareLocal(tb);
            Label next = gen.DefineLabel();
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Isinst, tb);
            gen.Emit(OpCodes.Stloc, other);
            gen.Emit(OpCodes.Ldloc, other);
            gen.Emit(OpCodes.Brtrue_S, next);
            gen.Emit(OpCodes.Ldc_I4_0);
            gen.Emit(OpCodes.Ret);
            gen.MarkLabel(next);
            foreach (FieldInfo field in fields)
            {
                Type ft = field.FieldType;
                Type ct = typeof(EqualityComparer<>).MakeGenericType(ft);
                next = gen.DefineLabel();
                gen.EmitCall(OpCodes.Call, ct.GetMethod("get_Default"), null);
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldfld, field);
                gen.Emit(OpCodes.Ldloc, other);
                gen.Emit(OpCodes.Ldfld, field);
                gen.EmitCall(OpCodes.Callvirt, ct.GetMethod("Equals", new Type[] { ft, ft, }), null);
                gen.Emit(OpCodes.Brtrue_S, next);
                gen.Emit(OpCodes.Ldc_I4_0);
                gen.Emit(OpCodes.Ret);
                gen.MarkLabel(next);
            }
            gen.Emit(OpCodes.Ldc_I4_1);
            gen.Emit(OpCodes.Ret);
        }

        private static void GenerateGetHashCode(TypeBuilder tb, IEnumerable<FieldInfo> fields)
        {
            MethodBuilder mb = tb.DefineMethod("GetHashCode",
                                               MethodAttributes.Public | MethodAttributes.ReuseSlot |
                                               MethodAttributes.Virtual | MethodAttributes.HideBySig,
                                               typeof(Int32), Type.EmptyTypes);
            ILGenerator gen = mb.GetILGenerator();
            gen.Emit(OpCodes.Ldc_I4_0);
            foreach (FieldInfo field in fields)
            {
                Type ft = field.FieldType;
                Type ct = typeof(EqualityComparer<>).MakeGenericType(ft);
                gen.EmitCall(OpCodes.Call, ct.GetMethod("get_Default"), null);
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Ldfld, field);
                gen.EmitCall(OpCodes.Callvirt, ct.GetMethod("GetHashCode", new Type[] { ft, }), null);
                gen.Emit(OpCodes.Xor);
            }
            gen.Emit(OpCodes.Ret);
        }
    }

    #endregion

    #region "Clase ParseException"

    public sealed class ParseException
        : Exception
    {
        public ParseException(String message, Int32 position)
            : base(message)
        {
            this.Position = position;
        }

        public Int32 Position { get; private set; }

        public override String ToString()
        {
            return String.Format(ExpressionParser.Res.ParseExceptionFormat, this.Message, this.Position);
        }
    }

    #endregion

    #region "Clase ExpressionParser"

    internal class ExpressionParser
    {
        #region Nested Types

        private struct Token
        {
            public TokenId Id;
            public String Text;
            public Int32 Pos;
        }

        private enum TokenId
        {
            Unknown = 0,
            End,
            Identifier,
            StringLiteral,
            IntegerLiteral,
            RealLiteral,
            Exclamation,
            Percent,
            Amphersand,
            OpenParen,
            CloseParen,
            Asterisk,
            Plus,
            Comma,
            Minus,
            Dot,
            Slash,
            Colon,
            LessThan,
            Equal,
            GreaterThan,
            Question,
            OpenBracket,
            CloseBracket,
            Bar,
            ExclamationEqual,
            DoubleAmphersand,
            LessThanEqual,
            LessGreater,
            DoubleEqual,
            GreaterThanEqual,
            DoubleBar,
            Semicolon,
            ColonEqual,
        }

        private interface ILogicalSignatures
        {
            void F(Boolean x, Boolean y);
            void F(Nullable<Boolean> x, Nullable<Boolean> y);
        }

        private interface IArithmeticSignatures
        {
            void F(Int32 x, Int32 y);
            void F(UInt32 x, UInt32 y);
            void F(Int64 x, Int64 y);
            void F(UInt64 x, UInt64 y);
            void F(Single x, Single y);
            void F(Double x, Double y);
            void F(Decimal x, Decimal y);
            void F(Nullable<Int32> x, Nullable<Int32> y);
            void F(Nullable<UInt32> x, Nullable<UInt32> y);
            void F(Nullable<Int64> x, Nullable<Int64> y);
            void F(Nullable<UInt64> x, Nullable<UInt64> y);
            void F(Nullable<Single> x, Nullable<Single> y);
            void F(Nullable<Double> x, Nullable<Double> y);
            void F(Nullable<Decimal> x, Nullable<Decimal> y);
        }

        private interface IRelationalSignatures
            : IArithmeticSignatures
        {
            void F(String x, String y);
            void F(Char x, Char y);
            void F(DateTime x, DateTime y);
            void F(TimeSpan x, TimeSpan y);
            void F(Nullable<Char> x, Nullable<Char> y);
            void F(Nullable<DateTime> x, Nullable<DateTime> y);
            void F(Nullable<TimeSpan> x, Nullable<TimeSpan> y);
        }

        private interface IEqualitySignatures
            : IRelationalSignatures
        {
            void F(Boolean x, Boolean y);
            void F(Nullable<Boolean> x, Nullable<Boolean> y);
        }

        private interface IAddSignatures
            : IArithmeticSignatures
        {
            void F(DateTime x, TimeSpan y);
            void F(TimeSpan x, TimeSpan y);
            void F(Nullable<DateTime> x, Nullable<TimeSpan> y);
            void F(Nullable<TimeSpan> x, Nullable<TimeSpan> y);
        }

        private interface ISubtractSignatures
            : IAddSignatures
        {
            void F(DateTime x, DateTime y);
            void F(Nullable<DateTime> x, Nullable<DateTime> y);
        }

        private interface INegationSignatures
        {
            void F(Int32 x);
            void F(Int64 x);
            void F(Single x);
            void F(Double x);
            void F(Decimal x);
            void F(Nullable<Int32> x);
            void F(Nullable<Int64> x);
            void F(Nullable<Single> x);
            void F(Nullable<Double> x);
            void F(Nullable<Decimal> x);
        }

        private interface INotSignatures
        {
            void F(Boolean x);
            void F(Nullable<Boolean> x);
        }

        internal static class Res
        {
            internal const String DuplicateIdentifier = "The identifier '{0}' was defined more than once";
            internal const String ExpressionTypeMismatch = "Expression of type '{0}' expected";
            internal const String ExpressionExpected = "Expression expected";
            internal const String InvalidIntegerLiteral = "Invalid integer literal '{0}'";
            internal const String InvalidRealLiteral = "Invalid real literal '{0}'";
            internal const String UnknownIdentifier = "Unknown identifier '{0}'";
            internal const String NoItInScope = "No 'it' is in scope";
            internal const String IifRequiresThreeArgs = "The 'iif' function requires three arguments";
            internal const String FirstExprMustBeBool = "The first expression must be of type 'Boolean'";
            internal const String BothTypesConvertToOther = "Both of the types '{0}' and '{1}' convert to the other";

            internal const String NeitherTypeConvertsToOther =
                "Neither of the types '{0}' and '{1}' converts to the other";

            internal const String MissingAsClause = "Expression is missing an 'as' clause";
            internal const String ArgsIncompatibleWithLambda = "Argument list incompatible with lambda expression";
            internal const String TypeHasNoNullableForm = "Type '{0}' has no nullable form";
            internal const String NoMatchingConstructor = "No matching constructor in type '{0}'";
            internal const String AmbiguousConstructorInvocation = "Ambiguous invocation of '{0}' constructor";
            internal const String CannotConvertValue = "A value of type '{0}' cannot be converted to type '{1}'";
            internal const String NoApplicableMethod = "No applicable method '{0}' exists in type '{1}'";
            internal const String AmbiguousMethodInvocation = "Ambiguous invocation of method '{0}' in type '{1}'";
            internal const String UnknownPropertyOrField = "No property or field '{0}' exists in type '{1}'";
            internal const String NoApplicableAggregate = "No applicable aggregate method '{0}' exists";
            internal const String CannotIndexMultiDimArray = "Indexing of multi-dimensional arrays is not supported";
            internal const String InvalidIndex = "Array index must be an integer expression";
            internal const String NoApplicableIndexer = "No applicable indexer exists in type '{0}'";
            internal const String AmbiguousIndexerInvocation = "Ambiguous invocation of indexer in type '{0}'";
            internal const String IncompatibleOperand = "Operator '{0}' incompatible with operand type '{1}'";

            internal const String IncompatibleOperands =
                "Operator '{0}' incompatible with operand types '{1}' and '{2}'";

            internal const String UnterminatedStringLiteral = "Unterminated String literal";
            internal const String InvalidCharacter = "Syntax error '{0}'";
            internal const String DigitExpected = "Digit expected";
            internal const String SyntaxError = "Syntax error";
            internal const String TokenExpected = "{0} expected";
            internal const String ParseExceptionFormat = "{0} (at index {1})";
            internal const String ColonExpected = "':' expected";
            internal const String OpenParenExpected = "'(' expected";
            internal const String CloseParenOrOperatorExpected = "')' or operator expected";
            internal const String CloseParenOrCommaExpected = "')' or ',' expected";
            internal const String DotOrOpenParenExpected = "'.' or '(' expected";
            internal const String OpenBracketExpected = "'[' expected";
            internal const String CloseBracketOrCommaExpected = "']' or ',' expected";
            internal const String IdentifierExpected = "Identifier expected";
        }

        #endregion

        private HashSet<Type> APredefinedTypes;

        private static readonly Expression TrueLiteral = Expression.Constant(true);
        private static readonly Expression FalseLiteral = Expression.Constant(false);
        private static readonly Expression NullLiteral = Expression.Constant(null);

        private const String KeywordIt = "it";
        private const String KeywordIif = "iif";
        private const String KeywordNew = "new";

        private static Dictionary<String, Object> _keywords;

        private readonly Dictionary<String, Object> ASymbols;
        private readonly Dictionary<String, Object> AStatics;
        private readonly Dictionary<Expression, String> ALiterals;
        private ParameterExpression AIt;
        private readonly String AText;
        private Int32 ATextPos;
        private readonly Int32 ATextLen;
        private Char ACh;
        private Token AToken;

        public ExpressionParser(ParameterExpression[] parameters, String expression, Object[] values)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (_keywords == null)
            {
                _keywords = CreateKeywords();
            }
            this.ASymbols = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);
            this.AStatics = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);
            this.ALiterals = new Dictionary<Expression, String>();
            if (parameters != null)
            {
                this.ProcessParameters(parameters);
            }
            if (values != null)
            {
                this.ProcessValues(values);
            }

            this.ASymbols.Add("$", this.ASymbols);
            this.ASymbols.Add("$type", ((Expression<Func<String, Type>>)(s =>
                                                                         AppDomain.CurrentDomain.GetAssemblies()
                                                                             .Select(_ => _.GetType(s))
                                                                             .FirstOrDefault(_ => _ != null)
                                                                        )));

            AStatics.Add("#var", ((Action<String, String>)((s, t) =>
                                                                this.ASymbols.Add(s, Expression.Variable(AppDomain.CurrentDomain.GetAssemblies()
                                                                            .Select(_ => _.GetType(t))
                                                                            .FirstOrDefault(_ => _ != null), s))
                                                               )));
            AStatics.Add("#import", ((Action<String>)(t =>
                                                           this.APredefinedTypes.Add(
                                                               AppDomain.CurrentDomain.GetAssemblies()
                                                                   .Select(_ => _.GetType(t))
                                                                   .FirstOrDefault(_ => _ != null)
                                                               ))
                                        ));
            AText = expression;
            ATextLen = AText.Length;
            SetTextPos(0);
            NextToken();
        }

        private void ProcessParameters(ParameterExpression[] parameters)
        {
            foreach (ParameterExpression pe in parameters)
            {
                if (!String.IsNullOrEmpty(pe.Name))
                {
                    this.ASymbols.Add(pe.Name, pe);
                }
            }
            if (parameters.Length == 1 && String.IsNullOrEmpty(parameters[0].Name))
            {
                this.AIt = parameters[0];
            }
        }

        private void ProcessValues(Object[] values)
        {
            for (Int32 i = 0; i < values.Length; i++)
            {
                Object value = values[i];
                if (i == values.Length - 1 && value is IDictionary<String, Object>)
                {
                    foreach (KeyValuePair<String, Object> e in (IDictionary<String, Object>)value)
                    {
                        this.ASymbols.Add(e.Key, e.Value);
                    }
                }
                else
                {
                    this.ASymbols.Add("@" + i.ToString(CultureInfo.InvariantCulture), value);
                }
            }

            var imports = new HashSet<Type>(new[]
                                                          {
                                                              #region Predefined Types
                                                              typeof (Object),
                                                              typeof (Boolean),
                                                              typeof (Char),
                                                              typeof (String),
                                                              typeof (SByte),
                                                              typeof (Byte),
                                                              typeof (Int16),
                                                              typeof (UInt16),
                                                              typeof (Int32),
                                                              typeof (UInt32),
                                                              typeof (Int64),
                                                              typeof (UInt64),
                                                              typeof (Single),
                                                              typeof (Double),
                                                              typeof (Decimal),
                                                              typeof (DateTime),
                                                              typeof (TimeSpan),
                                                              typeof (Guid),
                                                              typeof (Math),
                                                              typeof (Convert),
                                                              typeof (Tuple),
                                                              typeof (Regex),
                                                              typeof (DynamicQueryable),
                                                              typeof (Queryable),
                                                              typeof (Enumerable),
                                                              //typeof (Status),
                                                              //typeof (User)
                                                              #endregion
                                                          });
            if (this.ASymbols.ContainsKey("#imports"))
            {
                foreach (Type t in (IEnumerable<Type>)this.ASymbols["#imports"])
                {
                    imports.Add(t);
                }
            }
            this.APredefinedTypes = imports;
        }

        public Expression Parse(Type resultType)
        {
            Int32 exprPos = this.AToken.Pos;
            Expression expr = this.ParseExpression();
            if (resultType != null && (expr = this.PromoteExpression(expr, resultType, true)) == null)
            {
                throw this.ParseError(exprPos, Res.ExpressionTypeMismatch, GetTypeName(resultType));
            }
            this.ValidateToken(TokenId.End, Res.SyntaxError);
            return expr;
        }

        public IEnumerable<DynamicOrdering> ParseOrdering()
        {
#pragma warning disable 0219
            var orderings = new List<DynamicOrdering>();
            while (true)
            {
                Expression expr = this.ParseExpression();
                Boolean ascending = true;
                if (this.TokenIdentifierIs("asc") || this.TokenIdentifierIs("ascending"))
                {
                    this.NextToken();
                }
                else if (this.TokenIdentifierIs("desc") || this.TokenIdentifierIs("descending"))
                {
                    this.NextToken();
                    ascending = false;
                }
                orderings.Add(new DynamicOrdering()
                                  {
                                      Selector = expr,
                                      Ascending = ascending
                                  });
                if (this.AToken.Id != TokenId.Comma)
                {
                    break;
                }
                this.NextToken();
            }
            this.ValidateToken(TokenId.End, Res.SyntaxError);
            return orderings;

#pragma warning restore 0219
        }

        // ; operator
        private Expression ParseExpression()
        {
            Expression left = this.ParseAssign();
            while (this.AToken.Id == TokenId.Semicolon)
            {
                this.NextToken();
                Expression right = this.ParseAssign();
                left = Expression.Block(
                    right.Type,
                    this.ASymbols.Values.OfType<ParameterExpression>(),
                    left is BlockExpression
                        ? ((BlockExpression)left).Expressions.Concat(new Expression[] { right, })
                        : new Expression[] { left, right, }
                    );
            }
            return left;
        }

        // := operator
        private Expression ParseAssign()
        {
            Expression left = this.ParseConditional();
            while (this.AToken.Id == TokenId.ColonEqual)
            {
                this.NextToken();
                Expression right = this.ParseConditional();
                if (left is MethodCallExpression)
                {
                    MethodCallExpression e = (MethodCallExpression)left;
                    left = Expression.Property(e.Object, e.Method.Name.Substring(4), e.Arguments.ToArray());
                }
                left = Expression.Assign(left, right);
            }
            return left;
        }

        // ?: operator
        private Expression ParseConditional()
        {
            Int32 errorPos = this.AToken.Pos;
            Expression expr = this.ParseLogicalOr();
            if (this.AToken.Id == TokenId.Question)
            {
                this.NextToken();
                Expression expr1 = this.ParseExpression();
                this.ValidateToken(TokenId.Colon, Res.ColonExpected);
                this.NextToken();
                Expression expr2 = this.ParseExpression();
                expr = this.GenerateConditional(expr, expr1, expr2, errorPos);
            }
            return expr;
        }

        // ||, or operator
        private Expression ParseLogicalOr()
        {
            Expression left = this.ParseLogicalAnd();
            while (this.AToken.Id == TokenId.DoubleBar || this.TokenIdentifierIs("or"))
            {
                Token op = this.AToken;
                this.NextToken();
                Expression right = this.ParseLogicalAnd();
                this.CheckAndPromoteOperands(typeof(ILogicalSignatures), op.Text, ref left, ref right, op.Pos);
                left = Expression.OrElse(left, right);
            }
            return left;
        }

        // &&, and operator
        private Expression ParseLogicalAnd()
        {
            Expression left = this.ParseComparison();
            while (this.AToken.Id == TokenId.DoubleAmphersand || this.TokenIdentifierIs("and"))
            {
                Token op = this.AToken;
                this.NextToken();
                Expression right = this.ParseComparison();
                this.CheckAndPromoteOperands(typeof(ILogicalSignatures), op.Text, ref left, ref right, op.Pos);
                left = Expression.AndAlso(left, right);
            }
            return left;
        }

        // =, ==, !=, <>, >, >=, <, <= operators
        private Expression ParseComparison()
        {
            Expression left = this.ParseAdditive();
            while (this.AToken.Id == TokenId.Equal || this.AToken.Id == TokenId.DoubleEqual ||
                   this.AToken.Id == TokenId.ExclamationEqual || this.AToken.Id == TokenId.LessGreater ||
                   this.AToken.Id == TokenId.GreaterThan || this.AToken.Id == TokenId.GreaterThanEqual ||
                   this.AToken.Id == TokenId.LessThan || this.AToken.Id == TokenId.LessThanEqual)
            {
                Token op = this.AToken;
                this.NextToken();
                Expression right = this.ParseAdditive();
                Boolean isEquality = op.Id == TokenId.Equal || op.Id == TokenId.DoubleEqual ||
                                     op.Id == TokenId.ExclamationEqual || op.Id == TokenId.LessGreater;
                if (isEquality && !left.Type.IsValueType && !right.Type.IsValueType)
                {
                    if (left.Type != right.Type)
                    {
                        if (left.Type.IsAssignableFrom(right.Type))
                        {
                            right = Expression.Convert(right, left.Type);
                        }
                        else if (right.Type.IsAssignableFrom(left.Type))
                        {
                            left = Expression.Convert(left, right.Type);
                        }
                        else
                        {
                            throw this.IncompatibleOperandsError(op.Text, left, right, op.Pos);
                        }
                    }
                }
                else if (IsEnumType(left.Type) || IsEnumType(right.Type))
                {
                    if (left.Type != right.Type)
                    {
                        Expression e;
                        if ((e = this.PromoteExpression(right, left.Type, true)) != null)
                        {
                            right = e;
                        }
                        else if ((e = this.PromoteExpression(left, right.Type, true)) != null)
                        {
                            left = e;
                        }
                        else
                        {
                            throw this.IncompatibleOperandsError(op.Text, left, right, op.Pos);
                        }
                    }
                }
                else
                {
                    this.CheckAndPromoteOperands(
                        isEquality ? typeof(IEqualitySignatures) : typeof(IRelationalSignatures),
                        op.Text, ref left, ref right, op.Pos);
                }
                switch (op.Id)
                {
                    case TokenId.Equal:
                    case TokenId.DoubleEqual:
                        left = this.GenerateEqual(left, right);
                        break;
                    case TokenId.ExclamationEqual:
                    case TokenId.LessGreater:
                        left = this.GenerateNotEqual(left, right);
                        break;
                    case TokenId.GreaterThan:
                        left = this.GenerateGreaterThan(left, right);
                        break;
                    case TokenId.GreaterThanEqual:
                        left = this.GenerateGreaterThanEqual(left, right);
                        break;
                    case TokenId.LessThan:
                        left = this.GenerateLessThan(left, right);
                        break;
                    case TokenId.LessThanEqual:
                        left = this.GenerateLessThanEqual(left, right);
                        break;
                }
            }
            return left;
        }

        // +, -, & operators
        private Expression ParseAdditive()
        {
            Expression left = this.ParseMultiplicative();
            while (this.AToken.Id == TokenId.Plus || this.AToken.Id == TokenId.Minus ||
                   this.AToken.Id == TokenId.Amphersand)
            {
                Token op = this.AToken;
                this.NextToken();
                Expression right = this.ParseMultiplicative();
                switch (op.Id)
                {
                    case TokenId.Plus:
                        if (left.Type == typeof(String) || right.Type == typeof(String))
                        {
                            goto case TokenId.Amphersand;
                        }
                        this.CheckAndPromoteOperands(typeof(IAddSignatures), op.Text, ref left, ref right, op.Pos);
                        left = this.GenerateAdd(left, right);
                        break;
                    case TokenId.Minus:
                        this.CheckAndPromoteOperands(typeof(ISubtractSignatures), op.Text, ref left, ref right, op.Pos);
                        left = this.GenerateSubtract(left, right);
                        break;
                    case TokenId.Amphersand:
                        left = this.GenerateStringConcat(left, right);
                        break;
                }
            }
            return left;
        }

        // *, /, %, mod operators
        private Expression ParseMultiplicative()
        {
            Expression left = this.ParseUnary();
            while (this.AToken.Id == TokenId.Asterisk || this.AToken.Id == TokenId.Slash ||
                   this.AToken.Id == TokenId.Percent || this.TokenIdentifierIs("mod"))
            {
                Token op = this.AToken;
                this.NextToken();
                Expression right = this.ParseUnary();
                this.CheckAndPromoteOperands(typeof(IArithmeticSignatures), op.Text, ref left, ref right, op.Pos);
                switch (op.Id)
                {
                    case TokenId.Asterisk:
                        left = Expression.Multiply(left, right);
                        break;
                    case TokenId.Slash:
                        left = Expression.Divide(left, right);
                        break;
                    case TokenId.Percent:
                    case TokenId.Identifier:
                        left = Expression.Modulo(left, right);
                        break;
                }
            }
            return left;
        }

        // -, !, not unary operators
        private Expression ParseUnary()
        {
            if (this.AToken.Id == TokenId.Minus || this.AToken.Id == TokenId.Exclamation ||
                this.TokenIdentifierIs("not"))
            {
                Token op = this.AToken;
                this.NextToken();
                if (op.Id == TokenId.Minus && (this.AToken.Id == TokenId.IntegerLiteral ||
                                               this.AToken.Id == TokenId.RealLiteral))
                {
                    this.AToken.Text = "-" + this.AToken.Text;
                    this.AToken.Pos = op.Pos;
                    return this.ParsePrimary();
                }
                Expression expr = this.ParseUnary();
                if (op.Id == TokenId.Minus)
                {
                    this.CheckAndPromoteOperand(typeof(INegationSignatures), op.Text, ref expr, op.Pos);
                    expr = Expression.Negate(expr);
                }
                else
                {
                    this.CheckAndPromoteOperand(typeof(INotSignatures), op.Text, ref expr, op.Pos);
                    expr = Expression.Not(expr);
                }
                return expr;
            }
            return this.ParsePrimary();
        }

        private Expression ParsePrimary()
        {
            Expression expr = this.ParsePrimaryStart();
            while (true)
            {
                switch (this.AToken.Id)
                {
                    case TokenId.Dot:
                        this.NextToken();
                        expr = this.ParseMemberAccess(null, expr);
                        break;
                    case TokenId.OpenBracket:
                        expr = this.ParseElementAccess(expr);
                        break;
                    default:
                        return expr;
                }
            }
        }

        private Expression ParsePrimaryStart()
        {
            switch (this.AToken.Id)
            {
                case TokenId.Identifier:
                    return this.ParseIdentifier();
                case TokenId.StringLiteral:
                    return this.ParseStringLiteral();
                case TokenId.IntegerLiteral:
                    return this.ParseIntegerLiteral();
                case TokenId.RealLiteral:
                    return this.ParseRealLiteral();
                case TokenId.OpenParen:
                    return this.ParseParenExpression();
                default:
                    throw this.ParseError(Res.ExpressionExpected);
            }
        }

        private Expression ParseStringLiteral()
        {
            this.ValidateToken(TokenId.StringLiteral);
            Char quote = this.AToken.Text[0];
            String s = this.AToken.Text.Substring(1, this.AToken.Text.Length - 2);
            Int32 start = 0;
            while (true)
            {
                Int32 i = s.IndexOf(quote, start);
                if (i < 0)
                {
                    break;
                }
                s = s.Remove(i, 1);
                start = i + 1;
            }
            if (quote == '\'')
            {
                // Treat quoting token ' as " and create Char literal only if quote is ' and literal
                // length is 1.
                this.NextToken();
                return this.CreateLiteral(quote == '\'' && s.Length == 1 ? (Object)s[0] : s, s);
            }
            this.NextToken();
            return this.CreateLiteral(s, s);
        }

        private Expression ParseIntegerLiteral()
        {
            this.ValidateToken(TokenId.IntegerLiteral);
            String text = this.AToken.Text;
            if (text[0] != '-')
            {
                UInt64 value;
                if (!UInt64.TryParse(text, out value))
                    throw this.ParseError(Res.InvalidIntegerLiteral, text);
                this.NextToken();
                if (value <= Int32.MaxValue)
                    return this.CreateLiteral((Int32)value, text);
                if (value <= UInt32.MaxValue)
                    return this.CreateLiteral((UInt32)value, text);
                if (value <= Int64.MaxValue)
                    return this.CreateLiteral((Int64)value, text);
                return this.CreateLiteral(value, text);
            }
            else
            {
                Int64 value;
                if (!Int64.TryParse(text, out value))
                {
                    throw this.ParseError(Res.InvalidIntegerLiteral, text);
                }
                this.NextToken();
                if (value >= Int32.MinValue && value <= Int32.MaxValue)
                {
                    return this.CreateLiteral((Int32)value, text);
                }
                return this.CreateLiteral(value, text);
            }
        }

        private Expression ParseRealLiteral()
        {
            this.ValidateToken(TokenId.RealLiteral);
            String text = this.AToken.Text;
            Object value = null;
            Char last = text[text.Length - 1];
            if (last == 'F' || last == 'f')
            {
                Single f;
                if (Single.TryParse(text.Substring(0, text.Length - 1), out f))
                {
                    value = f;
                }
            }
            else
            {
                Double d;
                if (Double.TryParse(text, out d))
                {
                    value = d;
                }
            }
            if (value == null)
            {
                throw this.ParseError(Res.InvalidRealLiteral, text);
            }
            this.NextToken();
            return this.CreateLiteral(value, text);
        }

        private Expression CreateLiteral(Object value, String text)
        {
            ConstantExpression expr = Expression.Constant(value);
            this.ALiterals.Add(expr, text);
            return expr;
        }

        private Expression ParseParenExpression()
        {
            this.ValidateToken(TokenId.OpenParen, Res.OpenParenExpected);
            this.NextToken();
            Expression e = this.ParseExpression();
            this.ValidateToken(TokenId.CloseParen, Res.CloseParenOrOperatorExpected);
            this.NextToken();
            return e;
        }

        private Expression ParseIdentifier()
        {
            this.ValidateToken(TokenId.Identifier);
            Object value;
            if (this.AToken.Text.StartsWith("#"))
            {
                value = this.AStatics[this.AToken.Text];
                this.NextToken();
                return Expression.Constant(value is Delegate
                                               ? ((Delegate)value).DynamicInvoke(this.ParseArgumentList()
                                                                                      .Cast<ConstantExpression>()
                                                                                      .Select(e => e.Value)
                                                                                      .ToArray()
                                                     )
                                               : value
                    );
            }
            if (_keywords.TryGetValue(this.AToken.Text, out value))
            {
                if (value == (Object)KeywordIt)
                {
                    return this.ParseIt();
                }
                if (value == (Object)KeywordIif)
                {
                    return this.ParseIif();
                }
                if (value == (Object)KeywordNew)
                {
                    return this.ParseNew();
                }
                this.NextToken();
                return (Expression)value;
            }
            else if ((value = this.APredefinedTypes.SingleOrDefault(t => t.Name == this.AToken.Text)) != null)
            {
                return this.ParseTypeAccess((Type)value);
            }
            if (this.ASymbols.TryGetValue(this.AToken.Text, out value))
            {
                Expression expr = value as Expression;
                if (expr == null)
                {
                    expr = Expression.Constant(value);
                }
                else
                {
                    LambdaExpression lambda = expr as LambdaExpression;
                    if (lambda != null)
                    {
                        return this.ParseLambdaInvocation(lambda);
                    }
                }
                this.NextToken();
                return expr;
            }
            else if (this.AIt.Type.GetMember(this.AToken.Text, BindingFlags.Public | BindingFlags.Instance).Any())
            {
                return this.ParseMemberAccess(null, this.AIt);
            }
            else
            {
                var expr = Expression.Property(
                    Expression.Constant(this.ASymbols),
                    "Item",
                    Expression.Constant(this.AToken.Text)
                    );
                this.NextToken();
                return expr;
            }
        }

        private Expression ParseIt()
        {
            if (this.AIt == null)
            {
                throw this.ParseError(Res.NoItInScope);
            }
            this.NextToken();
            return this.AIt;
        }

        private Expression ParseIif()
        {
            Int32 errorPos = this.AToken.Pos;
            this.NextToken();
            Expression[] args = this.ParseArgumentList();
            if (args.Length != 3)
            {
                throw this.ParseError(errorPos, Res.IifRequiresThreeArgs);
            }
            return this.GenerateConditional(args[0], args[1], args[2], errorPos);
        }

        private Expression GenerateConditional(Expression test, Expression expr1, Expression expr2, Int32 errorPos)
        {
            if (test.Type != typeof(Boolean))
            {
                throw this.ParseError(errorPos, Res.FirstExprMustBeBool);
            }
            if (expr1.Type != expr2.Type)
            {
                Expression expr1As2 = expr2 != NullLiteral ? this.PromoteExpression(expr1, expr2.Type, true) : null;
                Expression expr2As1 = expr1 != NullLiteral ? this.PromoteExpression(expr2, expr1.Type, true) : null;
                if (expr1As2 != null && expr2As1 == null)
                {
                    expr1 = expr1As2;
                }
                else if (expr2As1 != null && expr1As2 == null)
                {
                    expr2 = expr2As1;
                }
                else
                {
                    String type1 = expr1 != NullLiteral ? expr1.Type.Name : "null";
                    String type2 = expr2 != NullLiteral ? expr2.Type.Name : "null";
                    if (expr1As2 != null && expr2As1 != null)
                    {
                        throw this.ParseError(errorPos, Res.BothTypesConvertToOther, type1, type2);
                    }
                    throw this.ParseError(errorPos, Res.NeitherTypeConvertsToOther, type1, type2);
                }
            }
            return Expression.Condition(test, expr1, expr2);
        }

        private Expression ParseNew()
        {
            this.NextToken();
            this.ValidateToken(TokenId.OpenParen, Res.OpenParenExpected);
            this.NextToken();
            List<DynamicProperty> properties = new List<DynamicProperty>();
            List<Expression> expressions = new List<Expression>();
            while (true)
            {
                Int32 exprPos = this.AToken.Pos;
                Expression expr = this.ParseExpression();
                String propName;
                if (this.TokenIdentifierIs("as"))
                {
                    this.NextToken();
                    propName = this.GetIdentifier();
                    this.NextToken();
                }
                else
                {
                    MemberExpression me = expr as MemberExpression;
                    if (me == null)
                    {
                        throw this.ParseError(exprPos, Res.MissingAsClause);
                    }
                    propName = me.Member.Name;
                }
                expressions.Add(expr);
                properties.Add(new DynamicProperty(propName, expr.Type));
                if (this.AToken.Id != TokenId.Comma)
                {
                    break;
                }
                this.NextToken();
            }
            this.ValidateToken(TokenId.CloseParen, Res.CloseParenOrCommaExpected);
            this.NextToken();
            Type type = DynamicExpression.CreateClass(properties);
            MemberBinding[] bindings = new MemberBinding[properties.Count];
            for (Int32 i = 0; i < bindings.Length; i++)
            {
                bindings[i] = Expression.Bind(type.GetProperty(properties[i].Name), expressions[i]);
            }
            return Expression.MemberInit(Expression.New(type), bindings);
        }

        private Expression ParseLambdaInvocation(LambdaExpression lambda)
        {
            Int32 errorPos = this.AToken.Pos;
            this.NextToken();
            Expression[] args = this.ParseArgumentList();
            MethodBase method;
            if (this.FindMethod(lambda.Type, "Invoke", lambda, args, out method) != 1)
            {
                throw this.ParseError(errorPos, Res.ArgsIncompatibleWithLambda);
            }
            return Expression.Invoke(lambda, args);
        }

        private Expression ParseTypeAccess(Type type)
        {
            Int32 errorPos = this.AToken.Pos;
            this.NextToken();
            if (this.AToken.Id == TokenId.Question)
            {
                if (!type.IsValueType || IsNullableType(type))
                {
                    throw this.ParseError(errorPos, Res.TypeHasNoNullableForm, GetTypeName(type));
                }
                type = typeof(Nullable<>).MakeGenericType(type);
                this.NextToken();
            }
            if (this.AToken.Id == TokenId.OpenParen)
            {
                Expression[] args = this.ParseArgumentList();
                MethodBase method;
                switch (this.FindBestMethod(type.GetConstructors(), args, out method))
                {
                    case 0:
                        if (args.Length == 1)
                            return this.GenerateConversion(args[0], type, errorPos);
                        throw this.ParseError(errorPos, Res.NoMatchingConstructor, GetTypeName(type));
                    case 1:
                        return Expression.New((ConstructorInfo)method, args);
                    default:
                        throw this.ParseError(errorPos, Res.AmbiguousConstructorInvocation, GetTypeName(type));
                }
            }
            this.ValidateToken(TokenId.Dot, Res.DotOrOpenParenExpected);
            this.NextToken();
            return this.ParseMemberAccess(type, null);
        }

        private Expression GenerateConversion(Expression expr, Type type, Int32 errorPos)
        {
            Type exprType = expr.Type;
            if (exprType == type)
            {
                return expr;
            }
            if (exprType.IsValueType && type.IsValueType)
            {
                if ((IsNullableType(exprType) || IsNullableType(type)) &&
                    GetNonNullableType(exprType) == GetNonNullableType(type))
                {
                    return Expression.Convert(expr, type);
                }
                if ((IsNumericType(exprType) || IsEnumType(exprType)) &&
                    (IsNumericType(type)) || IsEnumType(type))
                {
                    return Expression.ConvertChecked(expr, type);
                }
            }
            if (exprType.IsAssignableFrom(type) || type.IsAssignableFrom(exprType) ||
                exprType.IsInterface || type.IsInterface)
            {
                return Expression.Convert(expr, type);
            }
            throw this.ParseError(errorPos, Res.CannotConvertValue,
                                  GetTypeName(exprType), GetTypeName(type));
        }

        private Expression ParseMemberAccess(Type type, Expression instance)
        {
            if (instance != null)
            {
                type = instance.Type;
            }
            Int32 errorPos = this.AToken.Pos;
            String id = this.GetIdentifier();
            this.NextToken();
            if (this.AToken.Id == TokenId.OpenParen)
            {
                // ParseAggregate method ("A subset of the Standard Query Operators" in document) is disused.

                Expression[] args = this.ParseArgumentList();
                MethodBase mb;
                switch (this.FindMethod(type, id, instance, args, out mb))
                {
                    case 0:
                        throw this.ParseError(errorPos, Res.NoApplicableMethod,
                                              id, GetTypeName(type));
                    case 1:
                        MethodInfo method = (MethodInfo)mb;
                        if (method.IsGenericMethodDefinition)
                        {
                            Type thisArgType = method.GetParameters().First().ParameterType;
                            // if the method like Method<T>(Something<T> arg)
                            if (method.GetGenericArguments().First() == thisArgType.GetGenericArguments().First())
                            {
                                method = method.MakeGenericMethod(new Type[]
                                                                      {
                                                                          GetAssignableTypes(instance.Type)
                                                                              .Single(
                                                                                  t =>
                                                                                  GetRealDefinitionType(t) ==
                                                                                  GetRealDefinitionType(thisArgType))
                                                                              .GetGenericArguments()
                                                                              .First()
                                                                      });
                            }
                        }
                        ParameterInfo[] parameters = method.GetParameters();
                        if (IsExtensionMethod(method))
                        {
                            parameters = parameters.Skip(1).ToArray();
                        }
                        if (parameters.Any() && Attribute.IsDefined(parameters.Last(), typeof(ParamArrayAttribute)))
                        {
                            Type t = parameters.Last().ParameterType.GetElementType();
                            args = args.Take(parameters.Length - 1).Concat(new Expression[]
                                                                               {
                                                                                   Expression.NewArrayInit(
                                                                                       t,
                                                                                       args.Skip(parameters.Length - 1).
                                                                                           Select(
                                                                                               e =>
                                                                                               Expression.Convert(e, t))
                                                                                       ),
                                                                               }).ToArray();
                        }
                        return IsExtensionMethod(method)
                                   ? Expression.Call(null, method, new Expression[] { instance, }.Concat(args))
                                   : Expression.Call(instance, method, args);
                    default:
                        throw this.ParseError(errorPos, Res.AmbiguousMethodInvocation,
                                              id, GetTypeName(type));
                }
            }
            MemberInfo member = this.FindPropertyOrField(type, id, instance == null);
            if (member == null)
            {
                throw this.ParseError(errorPos, Res.UnknownPropertyOrField,
                                      id, GetTypeName(type));
            }
            return member is PropertyInfo
                       ? Expression.Property(instance, (PropertyInfo)member)
                       : Expression.Field(instance, (FieldInfo)member);
        }

        private Expression[] ParseArgumentList()
        {
            this.ValidateToken(TokenId.OpenParen, Res.OpenParenExpected);
            this.NextToken();
            Expression[] args = this.AToken.Id != TokenId.CloseParen ? this.ParseArguments() : new Expression[0];
            this.ValidateToken(TokenId.CloseParen, Res.CloseParenOrCommaExpected);
            this.NextToken();
            return args;
        }

        private Expression[] ParseArguments()
        {
            List<Expression> argList = new List<Expression>();
            while (true)
            {
                argList.Add(this.ParseExpression());
                if (this.AToken.Id != TokenId.Comma)
                {
                    break;
                }
                this.NextToken();
            }
            return argList.ToArray();
        }

        private Expression ParseElementAccess(Expression expr)
        {
            Int32 errorPos = this.AToken.Pos;
            this.ValidateToken(TokenId.OpenBracket, Res.OpenParenExpected);
            this.NextToken();
            Expression[] args = this.ParseArguments();
            this.ValidateToken(TokenId.CloseBracket, Res.CloseBracketOrCommaExpected);
            this.NextToken();
            if (expr.Type.IsArray)
            {
                if (expr.Type.GetArrayRank() != 1 || args.Length != 1)
                {
                    throw this.ParseError(errorPos, Res.CannotIndexMultiDimArray);
                }
                Expression index = this.PromoteExpression(args[0], typeof(Int32), true);
                if (index == null)
                {
                    throw this.ParseError(errorPos, Res.InvalidIndex);
                }
                return Expression.ArrayIndex(expr, index);
            }
            MethodBase mb;
            switch (this.FindIndexer(expr.Type, args, out mb))
            {
                case 0:
                    throw this.ParseError(errorPos, Res.NoApplicableIndexer,
                                          GetTypeName(expr.Type));
                case 1:
                    return Expression.Call(expr, (MethodInfo)mb, args);
                default:
                    throw this.ParseError(errorPos, Res.AmbiguousIndexerInvocation,
                                          GetTypeName(expr.Type));
            }
        }

        private static Boolean IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static Type GetNonNullableType(Type type)
        {
            return IsNullableType(type) ? type.GetGenericArguments()[0] : type;
        }

        private static String GetTypeName(Type type)
        {
            Type baseType = GetNonNullableType(type);
            String s = baseType.Name;
            if (type != baseType)
            {
                s += '?';
            }
            return s;
        }

        private static Boolean IsNumericType(Type type)
        {
            return GetNumericTypeKind(type) != 0;
        }

        private static Boolean IsSignedIntegralType(Type type)
        {
            return GetNumericTypeKind(type) == 2;
        }

        private static Boolean IsUnsignedIntegralType(Type type)
        {
            return GetNumericTypeKind(type) == 3;
        }

        private static Int32 GetNumericTypeKind(Type type)
        {
            type = GetNonNullableType(type);
            if (type.IsEnum)
            {
                return 0;
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return 1;
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return 2;
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return 3;
                default:
                    return 0;
            }
        }

        private static Boolean IsEnumType(Type type)
        {
            return GetNonNullableType(type).IsEnum;
        }

        private void CheckAndPromoteOperand(Type signatures, String opName, ref Expression expr, Int32 errorPos)
        {
            Expression[] args = new Expression[] { expr };
            MethodBase method;
            if (this.FindMethod(signatures, "F", expr, args, out method) != 1)
            {
                throw this.ParseError(errorPos, Res.IncompatibleOperand,
                                      opName, GetTypeName(args[0].Type));
            }
            expr = args[0];
        }

        private void CheckAndPromoteOperands(Type signatures, String opName, ref Expression left, ref Expression right,
                                             Int32 errorPos)
        {
            Expression[] args = new Expression[] { left, right, };
            MethodBase method;
            if (this.FindMethod(signatures, "F", left, args, out method) != 1)
            {
                throw this.IncompatibleOperandsError(opName, left, right, errorPos);
            }
            left = args[0];
            right = args[1];
        }

        private Exception IncompatibleOperandsError(String opName, Expression left, Expression right, Int32 pos)
        {
            return this.ParseError(pos, Res.IncompatibleOperands,
                                   opName, GetTypeName(left.Type), GetTypeName(right.Type));
        }

        private MemberInfo FindPropertyOrField(Type type, String memberName, Boolean staticAccess)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.DeclaredOnly |
                                 (staticAccess ? BindingFlags.Static : BindingFlags.Instance);
            return SelfAndBaseTypes(type)
                .Select(
                    t =>
                    t.FindMembers(MemberTypes.Property | MemberTypes.Field, flags, Type.FilterNameIgnoreCase, memberName))
                .Where(m => m.Length != 0)
                .Select(m => m[0])
                .FirstOrDefault();
        }

        private Int32 FindMethod(Type type, String methodName, Expression instance, Expression[] args,
                                 bool searchExtensionMethods, out MethodBase method)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.DeclaredOnly |
                                 (instance == null ? BindingFlags.Static : BindingFlags.Instance);
            foreach (MemberInfo[] members in SelfAndBaseTypes(type)
                .Select(t => t.FindMembers(MemberTypes.Method, flags, Type.FilterNameIgnoreCase, methodName))
                )
            {
                Int32 count = this.FindBestMethod(
                    (searchExtensionMethods
                         ? members.Where(m => IsExtensionMethod((MethodBase)m))
                         : members
                    ).Cast<MethodBase>(),
                    args, out method
                    );
                if (count != 0)
                {
                    return count;
                }
            }
            if (!(instance == null || searchExtensionMethods))
            {
                foreach (Type t in this.APredefinedTypes.Where(t => Attribute.IsDefined(t, typeof(ExtensionAttribute))))
                {
                    int count = this.FindMethod(t, methodName, null, new Expression[] { instance, }.Concat(args).ToArray(),
                                                true, out method);
                    if (count != 0)
                    {
                        return count;
                    }
                }
            }
            method = null;
            return 0;
        }

        private static Boolean IsExtensionMethod(MethodBase m)
        {
            return m.GetCustomAttributes(typeof(ExtensionAttribute), false).Any();
        }

        private Int32 FindMethod(Type type, string methodName, Expression instance, Expression[] args,
                                 out MethodBase method)
        {
            return this.FindMethod(type, methodName, instance, args, false, out method);
        }

        private Int32 FindIndexer(Type type, Expression[] args, out MethodBase method)
        {
            foreach (Type t in SelfAndBaseTypes(type))
            {
                MemberInfo[] members = t.GetDefaultMembers();
                if (members.Length != 0)
                {
                    IEnumerable<MethodBase> methods = members
                        .OfType<PropertyInfo>()
                        .Select(p => (MethodBase)p.GetGetMethod())
                        .Where(m => m != null);
                    Int32 count = this.FindBestMethod(methods, args, out method);
                    if (count != 0)
                    {
                        return count;
                    }
                }
            }
            method = null;
            return 0;
        }

        private static IEnumerable<Type> SelfAndBaseTypes(Type type)
        {
            if (type.IsInterface)
            {
                List<Type> types = new List<Type>();
                AddInterface(types, type);
                return types;
            }
            return SelfAndBaseClasses(type);
        }

        private static IEnumerable<Type> SelfAndBaseClasses(Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }

        private static void AddInterface(List<Type> types, Type type)
        {
            if (!types.Contains(type))
            {
                types.Add(type);
                foreach (Type t in type.GetInterfaces())
                {
                    AddInterface(types, t);
                }
            }
        }

        private class MethodData
        {
            public MethodBase MethodBase;
            public ParameterInfo[] Parameters;
            public Expression[] Args;
        }

        private Int32 FindBestMethod(IEnumerable<MethodBase> methods, Expression[] args, out MethodBase method)
        {
            MethodData[] applicable = methods
                .Select(m => new MethodData()
                                 {
                                     MethodBase = m,
                                     Parameters = m.GetParameters()
                                 })
                .Where(m => this.IsApplicable(m, args))
                .ToArray();
            if (applicable.Length > 1)
            {
                // All params-containing methods was handled as suitable in IsApplicable method
                // however parameter count is not matched.
                if (applicable.Any(m => HasParamsParameter(m) || m.MethodBase.ContainsGenericParameters))
                {
                    // There is more suitable method without type parameters
                    applicable = applicable.Where(m => !m.MethodBase.ContainsGenericParameters).ToArray();
                    if (applicable.Length > 1)
                    {
                        // There is more suitable method without params
                        applicable = applicable.Where(m => !HasParamsParameter(m)).ToArray();
                    }
                }
                else
                {
                    applicable = applicable
                        .Where(m => applicable.All(n => m == n || IsBetterThan(args, m, n)))
                        .ToArray();
                }
            }
            if (applicable.Length == 1)
            {
                MethodData md = applicable[0];
                for (Int32 i = 0; i < args.Length; i++)
                {
                    args[i] = md.Args[i];
                }
                method = md.MethodBase;
            }
            else
            {
                method = null;
            }
            return applicable.Length;
        }

        private Boolean IsApplicable(MethodData method, Expression[] args)
        {
            if (!(method.Parameters.Length == args.Length || HasParamsParameter(method)))
            {
                return false;
            }
            Expression[] promotedArgs = new Expression[args.Length];
            for (Int32 i = 0; i < args.Length; i++)
            {
                ParameterInfo pi = i < method.Parameters.Length
                                       ? method.Parameters[i]
                                       : method.Parameters.Last();
                if (pi.IsOut)
                {
                    return false;
                }
                Expression promoted = this.PromoteExpression(
                    args[i],
                    i >= method.Parameters.Length - 1 && HasParamsParameter(method)
                        ? pi.ParameterType.GetElementType()
                        : pi.ParameterType,
                    false
                    );
                if (promoted == null)
                {
                    return false;
                }
                promotedArgs[i] = promoted;
            }
            method.Args = promotedArgs;
            return true;
        }

        private static Boolean HasParamsParameter(MethodData method)
        {
            return method.Parameters.Any() &&
                   Attribute.IsDefined(method.Parameters.Last(), typeof(ParamArrayAttribute));
        }

        private Expression PromoteExpression(Expression expr, Type type, Boolean exact)
        {
            if (expr.Type == type)
            {
                return expr;
            }
            if (expr is ConstantExpression)
            {
                ConstantExpression ce = (ConstantExpression)expr;
                if (ce == NullLiteral)
                {
                    if (!type.IsValueType || IsNullableType(type))
                    {
                        return Expression.Constant(null, type);
                    }
                }
                else
                {
                    String text;
                    if (this.ALiterals.TryGetValue(ce, out text))
                    {
                        Type target = GetNonNullableType(type);
                        Object value = null;
                        switch (Type.GetTypeCode(ce.Type))
                        {
                            case TypeCode.Int32:
                            case TypeCode.UInt32:
                            case TypeCode.Int64:
                            case TypeCode.UInt64:
                                value = ParseNumber(text, target);
                                break;
                            case TypeCode.Double:
                                if (target == typeof(Decimal))
                                    value = ParseNumber(text, target);
                                break;
                            case TypeCode.String:
                                value = ParseEnum(text, target);
                                break;
                        }
                        if (value != null)
                        {
                            return Expression.Constant(value, type);
                        }
                    }
                }
            }
            if (IsCompatibleWith(expr.Type, type))
            {
                if (type.IsValueType || exact)
                {
                    return Expression.Convert(expr, type);
                }
                return expr;
            }
            return null;
        }

        private static Object ParseNumber(String text, Type type)
        {
            switch (Type.GetTypeCode(GetNonNullableType(type)))
            {
                case TypeCode.SByte:
                    sbyte sb;
                    if (sbyte.TryParse(text, out sb))
                    {
                        return sb;
                    }
                    break;
                case TypeCode.Byte:
                    byte b;
                    if (byte.TryParse(text, out b))
                    {
                        return b;
                    }
                    break;
                case TypeCode.Int16:
                    short s;
                    if (short.TryParse(text, out s))
                    {
                        return s;
                    }
                    break;
                case TypeCode.UInt16:
                    ushort us;
                    if (ushort.TryParse(text, out us))
                    {
                        return us;
                    }
                    break;
                case TypeCode.Int32:
                    Int32 i;
                    if (Int32.TryParse(text, out i))
                    {
                        return i;
                    }
                    break;
                case TypeCode.UInt32:
                    UInt32 ui;
                    if (UInt32.TryParse(text, out ui))
                    {
                        return ui;
                    }
                    break;
                case TypeCode.Int64:
                    Int64 l;
                    if (Int64.TryParse(text, out l))
                    {
                        return l;
                    }
                    break;
                case TypeCode.UInt64:
                    UInt64 ul;
                    if (UInt64.TryParse(text, out ul))
                    {
                        return ul;
                    }
                    break;
                case TypeCode.Single:
                    Single f;
                    if (Single.TryParse(text, out f))
                    {
                        return f;
                    }
                    break;
                case TypeCode.Double:
                    Double d;
                    if (Double.TryParse(text, out d))
                    {
                        return d;
                    }
                    break;
                case TypeCode.Decimal:
                    Decimal e;
                    if (Decimal.TryParse(text, out e))
                    {
                        return e;
                    }
                    break;
            }
            return null;
        }

        private static Object ParseEnum(String name, Type type)
        {
            if (type.IsEnum)
            {
                MemberInfo[] memberInfos = type.FindMembers(MemberTypes.Field,
                                                            BindingFlags.Public | BindingFlags.DeclaredOnly |
                                                            BindingFlags.Static,
                                                            Type.FilterNameIgnoreCase, name);
                if (memberInfos.Length != 0)
                {
                    return ((FieldInfo)memberInfos[0]).GetValue(null);
                }
            }
            return null;
        }

        private static Boolean IsCompatibleWith(Type source, Type target)
        {
            if (source == target)
            {
                return true;
            }
            if (!target.IsValueType)
            {
                return GetAssignableTypes(source)
                    .Select(GetRealDefinitionType)
                    .Contains(GetRealDefinitionType(target));
            }
            Type st = GetNonNullableType(source);
            Type tt = GetNonNullableType(target);
            if (st != source && tt == target)
            {
                return false;
            }
            TypeCode sc = st.IsEnum ? TypeCode.Object : Type.GetTypeCode(st);
            TypeCode tc = tt.IsEnum ? TypeCode.Object : Type.GetTypeCode(tt);
            switch (sc)
            {
                case TypeCode.SByte:
                    switch (tc)
                    {
                        case TypeCode.SByte:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.Byte:
                    switch (tc)
                    {
                        case TypeCode.Byte:
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.Int16:
                    switch (tc)
                    {
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.UInt16:
                    switch (tc)
                    {
                        case TypeCode.UInt16:
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.Int32:
                    switch (tc)
                    {
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.UInt32:
                    switch (tc)
                    {
                        case TypeCode.UInt32:
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.Int64:
                    switch (tc)
                    {
                        case TypeCode.Int64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.UInt64:
                    switch (tc)
                    {
                        case TypeCode.UInt64:
                        case TypeCode.Single:
                        case TypeCode.Double:
                        case TypeCode.Decimal:
                            return true;
                    }
                    break;
                case TypeCode.Single:
                    switch (tc)
                    {
                        case TypeCode.Single:
                        case TypeCode.Double:
                            return true;
                    }
                    break;
                default:
                    if (st == tt)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static IEnumerable<Type> GetAssignableTypes(Type t)
        {
            do
            {
                yield return t;
                foreach (Type i in t.GetInterfaces())
                {
                    yield return i;
                }
            } while ((t = t.BaseType) != null);
        }

        private static Type GetRealDefinitionType(Type t)
        {
            if (t.IsGenericType)
            {
                while (t != t.GetGenericTypeDefinition())
                {
                    t = t.GetGenericTypeDefinition();
                }
            }
            return t;
        }

        private static Boolean IsBetterThan(Expression[] args, MethodData m1, MethodData m2)
        {
            Boolean better = false;
            for (Int32 i = 0; i < args.Length; i++)
            {
                Int32 c = CompareConversions(args[i].Type,
                                             m1.Parameters[i].ParameterType,
                                             m2.Parameters[i].ParameterType);
                if (c < 0)
                {
                    return false;
                }
                if (c > 0)
                {
                    better = true;
                }
            }
            return better;
        }

        // Return 1 if s -> t1 is a better conversion than s -> t2
        // Return -1 if s -> t2 is a better conversion than s -> t1
        // Return 0 if neither conversion is better
        private static Int32 CompareConversions(Type s, Type t1, Type t2)
        {
            if (t1 == t2)
            {
                return 0;
            }
            if (s == t1)
            {
                return 1;
            }
            if (s == t2)
            {
                return -1;
            }
            Boolean t1T2 = IsCompatibleWith(t1, t2);
            Boolean t2T1 = IsCompatibleWith(t2, t1);
            if (t1T2 && !t2T1)
            {
                return 1;
            }
            if (t2T1 && !t1T2)
            {
                return -1;
            }
            if (IsSignedIntegralType(t1) && IsUnsignedIntegralType(t2))
            {
                return 1;
            }
            if (IsSignedIntegralType(t2) && IsUnsignedIntegralType(t1))
            {
                return -1;
            }
            return 0;
        }

        private Expression GenerateEqual(Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }

        private Expression GenerateNotEqual(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }

        private Expression GenerateGreaterThan(Expression left, Expression right)
        {
            if (left.Type == typeof(String))
            {
                return Expression.GreaterThan(
                    this.GenerateStaticMethodCall("Compare", left, right),
                    Expression.Constant(0)
                    );
            }
            return Expression.GreaterThan(left, right);
        }

        private Expression GenerateGreaterThanEqual(Expression left, Expression right)
        {
            if (left.Type == typeof(String))
            {
                return Expression.GreaterThanOrEqual(
                    this.GenerateStaticMethodCall("Compare", left, right),
                    Expression.Constant(0)
                    );
            }
            return Expression.GreaterThanOrEqual(left, right);
        }

        private Expression GenerateLessThan(Expression left, Expression right)
        {
            if (left.Type == typeof(String))
            {
                return Expression.LessThan(
                    this.GenerateStaticMethodCall("Compare", left, right),
                    Expression.Constant(0)
                    );
            }
            return Expression.LessThan(left, right);
        }

        private Expression GenerateLessThanEqual(Expression left, Expression right)
        {
            if (left.Type == typeof(String))
            {
                return Expression.LessThanOrEqual(
                    this.GenerateStaticMethodCall("Compare", left, right),
                    Expression.Constant(0)
                    );
            }
            return Expression.LessThanOrEqual(left, right);
        }

        private Expression GenerateAdd(Expression left, Expression right)
        {
            if (left.Type == typeof(String) && right.Type == typeof(String))
            {
                return this.GenerateStaticMethodCall("Concat", left, right);
            }
            return Expression.Add(left, right);
        }

        private Expression GenerateSubtract(Expression left, Expression right)
        {
            return Expression.Subtract(left, right);
        }

        private Expression GenerateStringConcat(Expression left, Expression right)
        {
            return Expression.Call(
                null,
                typeof(String).GetMethod("Concat", new[] { typeof(Object), typeof(Object), }),
                new[] { left, right, }
                );
        }

        private MethodInfo GetStaticMethod(String methodName, Expression left, Expression right)
        {
            return left.Type.GetMethod(methodName, new[] { left.Type, right.Type, });
        }

        private Expression GenerateStaticMethodCall(String methodName, Expression left, Expression right)
        {
            return Expression.Call(null, this.GetStaticMethod(methodName, left, right), new[] { left, right, });
        }

        private void SetTextPos(Int32 pos)
        {
            this.ATextPos = pos;
            this.ACh = this.ATextPos < this.ATextLen ? this.AText[this.ATextPos] : '\0';
        }

        private void NextChar()
        {
            if (this.ATextPos < this.ATextLen)
                this.ATextPos++;
            this.ACh = this.ATextPos < this.ATextLen ? this.AText[this.ATextPos] : '\0';
        }

        private void NextToken()
        {
            while (Char.IsWhiteSpace(this.ACh))
            {
                this.NextChar();
            }
            TokenId t;
            Int32 tokenPos = this.ATextPos;
            switch (this.ACh)
            {
                case '!':
                    this.NextChar();
                    if (this.ACh == '=')
                    {
                        this.NextChar();
                        t = TokenId.ExclamationEqual;
                    }
                    else
                    {
                        t = TokenId.Exclamation;
                    }
                    break;
                case '%':
                    this.NextChar();
                    t = TokenId.Percent;
                    break;
                case '&':
                    this.NextChar();
                    if (this.ACh == '&')
                    {
                        this.NextChar();
                        t = TokenId.DoubleAmphersand;
                    }
                    else
                    {
                        t = TokenId.Amphersand;
                    }
                    break;
                case '(':
                    this.NextChar();
                    t = TokenId.OpenParen;
                    break;
                case ')':
                    this.NextChar();
                    t = TokenId.CloseParen;
                    break;
                case '*':
                    this.NextChar();
                    t = TokenId.Asterisk;
                    break;
                case '+':
                    this.NextChar();
                    t = TokenId.Plus;
                    break;
                case ',':
                    this.NextChar();
                    t = TokenId.Comma;
                    break;
                case '-':
                    this.NextChar();
                    t = TokenId.Minus;
                    break;
                case '.':
                    this.NextChar();
                    t = TokenId.Dot;
                    break;
                case '/':
                    this.NextChar();
                    t = TokenId.Slash;
                    break;
                case ':':
                    this.NextChar();
                    switch (this.ACh)
                    {
                        case '=':
                            this.NextChar();
                            t = TokenId.ColonEqual;
                            break;
                        default:
                            t = TokenId.Colon;
                            break;
                    }
                    break;
                case ';':
                    this.NextChar();
                    t = TokenId.Semicolon;
                    break;
                case '<':
                    this.NextChar();
                    switch (this.ACh)
                    {
                        case '=':
                            this.NextChar();
                            t = TokenId.LessThanEqual;
                            break;
                        case '>':
                            this.NextChar();
                            t = TokenId.LessGreater;
                            break;
                        default:
                            t = TokenId.LessThan;
                            break;
                    }
                    break;
                case '=':
                    this.NextChar();
                    if (this.ACh == '=')
                    {
                        this.NextChar();
                        t = TokenId.DoubleEqual;
                    }
                    else
                    {
                        t = TokenId.Equal;
                    }
                    break;
                case '>':
                    this.NextChar();
                    if (this.ACh == '=')
                    {
                        this.NextChar();
                        t = TokenId.GreaterThanEqual;
                    }
                    else
                    {
                        t = TokenId.GreaterThan;
                    }
                    break;
                case '?':
                    this.NextChar();
                    t = TokenId.Question;
                    break;
                case '[':
                    this.NextChar();
                    t = TokenId.OpenBracket;
                    break;
                case ']':
                    this.NextChar();
                    t = TokenId.CloseBracket;
                    break;
                case '|':
                    this.NextChar();
                    if (this.ACh == '|')
                    {
                        this.NextChar();
                        t = TokenId.DoubleBar;
                    }
                    else
                    {
                        t = TokenId.Bar;
                    }
                    break;
                case '"':
                case '\'':
                    Char quote = this.ACh;
                    do
                    {
                        this.NextChar();
                        while (this.ATextPos < this.ATextLen && this.ACh != quote)
                        {
                            this.NextChar();
                        }
                        if (this.ATextPos == this.ATextLen)
                        {
                            throw this.ParseError(this.ATextPos, Res.UnterminatedStringLiteral);
                        }
                        this.NextChar();
                    } while (this.ACh == quote);
                    t = TokenId.StringLiteral;
                    break;
                default:
                    if (Char.IsLetter(this.ACh) || this.ACh == '@' || this.ACh == '_' || this.ACh == '$' || this.ACh == '#')
                    {
                        do
                        {
                            this.NextChar();
                        } while (Char.IsLetterOrDigit(this.ACh) || this.ACh == '_');
                        t = TokenId.Identifier;
                        break;
                    }
                    if (Char.IsDigit(this.ACh))
                    {
                        t = TokenId.IntegerLiteral;
                        do
                        {
                            this.NextChar();
                        } while (Char.IsDigit(this.ACh));
                        if (this.ACh == '.')
                        {
                            t = TokenId.RealLiteral;
                            this.NextChar();
                            this.ValidateDigit();
                            do
                            {
                                this.NextChar();
                            } while (Char.IsDigit(this.ACh));
                        }
                        if (this.ACh == 'E' || this.ACh == 'e')
                        {
                            t = TokenId.RealLiteral;
                            this.NextChar();
                            if (this.ACh == '+' || this.ACh == '-')
                                this.NextChar();
                            this.ValidateDigit();
                            do
                            {
                                this.NextChar();
                            } while (Char.IsDigit(this.ACh));
                        }
                        if (this.ACh == 'F' || this.ACh == 'f')
                            this.NextChar();
                        break;
                    }
                    if (this.ATextPos == this.ATextLen)
                    {
                        t = TokenId.End;
                        break;
                    }
                    throw this.ParseError(this.ATextPos, Res.InvalidCharacter, this.ACh);
            }
            this.AToken.Id = t;
            this.AToken.Text = this.AText.Substring(tokenPos, this.ATextPos - tokenPos);
            this.AToken.Pos = tokenPos;
        }

        private Boolean TokenIdentifierIs(String id)
        {
            return this.AToken.Id == TokenId.Identifier &&
                   String.Equals(id, this.AToken.Text, StringComparison.OrdinalIgnoreCase);
        }

        private String GetIdentifier()
        {
            this.ValidateToken(TokenId.Identifier, Res.IdentifierExpected);
            String id = this.AToken.Text;
            if (id.Length > 1 && id[0] == '@')
            {
                id = id.Substring(1);
            }
            return id;
        }

        private void ValidateDigit()
        {
            if (!Char.IsDigit(this.ACh))
            {
                throw this.ParseError(this.ATextPos, Res.DigitExpected);
            }
        }

        private void ValidateToken(TokenId t, String errorMessage)
        {
            if (this.AToken.Id != t)
            {
                throw this.ParseError(errorMessage);
            }
        }

        private void ValidateToken(TokenId t)
        {
            if (this.AToken.Id != t)
            {
                throw this.ParseError(Res.SyntaxError);
            }
        }

        private Exception ParseError(String format, params Object[] args)
        {
            return this.ParseError(this.AToken.Pos, format, args);
        }

        private Exception ParseError(Int32 pos, String format, params Object[] args)
        {
            return new ParseException(String.Format(CultureInfo.CurrentCulture, format, args), pos);
        }

        private static Dictionary<String, Object> CreateKeywords()
        {
            Dictionary<String, Object> d = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase)
                                               {
                                                   {"true", TrueLiteral},
                                                   {"false", FalseLiteral},
                                                   {"null", NullLiteral},
                                                   {KeywordIt, KeywordIt},
                                                   {KeywordIif, KeywordIif},
                                                   {KeywordNew, KeywordNew},
                                               };
            return d;
        }
    }

    #endregion
}