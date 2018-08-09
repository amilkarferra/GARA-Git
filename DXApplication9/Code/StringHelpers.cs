using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DXApplication9
{
    public static class StringHelpers
    {
        #region Constantes

        private const char QueryStringDelimiter = '&';

        #endregion Constants

        #region Members

        private static RijndaelManaged _cryptoProvider;
        //Encriptacion de 128 bits: NO CAMBIAR   
        private static readonly byte[] Key = { 18, 19, 8, 24, 36, 22, 4, 22, 17, 5, 11, 9, 13, 15, 06, 23 };
        private static readonly byte[] Iv = { 14, 2, 16, 7, 5, 9, 17, 8, 4, 47, 16, 12, 1, 32, 25, 18 };

        #endregion Miembros

        #region Constructor

        static StringHelpers()
        {
            _cryptoProvider = new RijndaelManaged();
            _cryptoProvider.Mode = CipherMode.CBC;
            _cryptoProvider.Padding = PaddingMode.PKCS7;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Encripta la cadena dada
        /// </summary>
        /// <param name="unencryptedString">Unencrypted string</param>
        /// <returns>Returns an encrypted string</returns>
        public static string Encrypt(string unencryptedString)
        {
            var bytIn = Encoding.ASCII.GetBytes(unencryptedString);

            // Crea un MemoryStream
            var ms = new MemoryStream();

            // Crea Crypto Stream que encripta un stream
            var cs = new CryptoStream(ms, _cryptoProvider.CreateEncryptor(Key, Iv), CryptoStreamMode.Write);

            // Write content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            var bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        /// <summary>
        /// Desencripta la cadena dada
        /// </summary>
        /// <param name="encryptedString">Encrypted string</param>
        /// <returns>Retorna a cadena desencriptada</returns>
        public static string Decrypt(string encryptedString)
        {
            if (encryptedString.Trim().Length != 0)
            {
                byte[] bytIn = null;

                // Convierte de  Base64 a binary
                try
                {
                    bytIn = Convert.FromBase64String(encryptedString);

                }
                catch (Exception ex)
                {
                    if (typeof(FormatException) == ex.GetType())
                    {
                        throw new ArgumentException("La Cadena no se encuentra en el formato Correcto");
                    }

                }
                // Crea un MemoryStream
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);

                // Crea un CryptoStream que desencripta el dato
                CryptoStream cs = new CryptoStream(ms,
                    _cryptoProvider.CreateDecryptor(Key, Iv),
                    CryptoStreamMode.Read);

                // Lee el Crypto Stream
                StreamReader sr = new StreamReader(cs);

                return sr.ReadToEnd();
            }
            else
            {
                return "";
            }
        }

        //public static NameValueCollection DecryptQueryString(string queryString)
        //{
        //    if (queryString.Length != 0)
        //    {
        //        //Decodifica la cadena
        //        string decodedQueryString = HttpUtility.UrlDecode(queryString);

        //        //Desencripta la cadena
        //        string decryptedQueryString = StringHelpers.Decrypt(decodedQueryString);

        //        //Hago un split de la cadena basado en cada parámetro
        //        string[] actionQueryString = decryptedQueryString.Split(new char[] { QUERY_STRING_DELIMITER });

        //        NameValueCollection newQueryString = new NameValueCollection();

        //        //Hago un ciclo por cada par de nombre valor
        //        for (int index = 0; index < actionQueryString.Length; index++)
        //        {
        //            string[] queryStringItem = actionQueryString[index].Split(new char[] { '=' });
        //            newQueryString.Add(queryStringItem[0], queryStringItem[1]);
        //        }

        //        return newQueryString;
        //    }
        //    else
        //    {
        //        //Ninguna cadena fue pasada
        //        return null;
        //    }
        //}

        //public static string EncryptQueryString(NameValueCollection queryString)
        //{
        //    //Creo una cadena por cada valor pasado en la cadena
        //    string tempQueryString = "";

        //    for (int index = 0; index < queryString.Count; index++)
        //    {
        //        tempQueryString += queryString.GetKey(index) + "=" + queryString[index];
        //        if (index != queryString.Count - 1)
        //        {
        //            tempQueryString += QUERY_STRING_DELIMITER;
        //        }
        //    }

        //    return EncryptQueryString(tempQueryString);
        //}


        //public static string EncryptQueryString(string queryString)
        //{
        //    return "?" + HttpUtility.UrlEncode(StringHelpers.Encrypt(queryString));
        //}
        /// <summary>
        /// Obtiene los caracteres a la derecha de la cadena
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        //public static string Right(this string cadena, int cantidad)
        //{
        //    return Microsoft.VisualBasic.Strings.Right(cadena, cantidad);

        //    //try
        //    //{
        //    //    if (cadena.Length - cantidad + 1 < cantidad)
        //    //        return "";
        //    //    return cadena.Substring(cadena.Length - cantidad, cantidad);
        //    //}
        //    //catch (Exception exception)
        //    //{

        //    //    throw new ArgumentException(exception.Message);
        //    //}


        //}
        /// <summary>
        /// Obtiene los caracteres a la izquierda de la cadena
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static string Left(this string cadena, int cantidad)
        {

            try
            {
                return cadena.Substring(0, cantidad);
            }
            catch
            {

                return String.Empty;
            }


        }
        /// <summary>
        /// Devolver una cadena que está dentro de una cadena
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="ConexionSql"></param>
        /// <returns></returns>
        public static string DevolverNombreBaseDatos(string conexionSql)
        {
            int posicion = 0; //= conexionSql.TakeWhile(=="Catalog="); //) "Catalog=");
            string picaConexionSql = conexionSql.Substring(posicion + 10, conexionSql.Length);
            int posicionFinal = picaConexionSql.CompareTo(";");
            string bDatos = picaConexionSql.Substring(0, posicionFinal);
            return bDatos;
        }

        /// <summary>
        /// Devuelve las palabras con la primera letra en Mayúscula y las demás en minúncula
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string TipoFrase(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena)) return ""; var sb = new StringBuilder(cadena.Length);
            string[] cadSep = cadena.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in cadSep)
            {
                if (sb.Length > 0) sb.Append(' ');
                sb.Append(char.ToUpper(item[0]));
                if (item.Length > 1)
                    sb.Append(item.ToLower(), 1, item.Length - 1);
            }
            return sb.ToString();
        }

        public static string TipoOracion(this string cadena)
        {
            if (string.IsNullOrEmpty(cadena)) return ""; cadena = cadena.Trim();
            return cadena[0].ToString().ToUpper() + cadena.Substring(1, cadena.Length - 1).ToLower();
        }

        /// <summary>
        /// Conforma una oracion de una palabra separada por mayusculas
        /// </summary>
        /// <example>si PalabraDeEjemplo devuelve la oracion 'Palabra De Ejemplo' </example>
        /// <param name="aWord"></param>
        /// <returns></returns>
        public static string SplitUpperCase(this string aWord)
        {
            if (String.IsNullOrEmpty(aWord)) return "";
            bool primeraLetra = false;
            string sentence = null;
            var array = aWord.ToCharArray();
            foreach (char c in array)
            {
                if (c.ToString().ToUpper().CompareTo(c.ToString()) == 0) //Indica que es Mayuscula
                {
                    sentence += string.Format("{0} {1}", " ", primeraLetra ? c.ToString() : c.ToString().ToLower());
                }
                else
                {
                    sentence += c;
                }

            }
            return sentence.Trim();
        }

        /// <summary>
        /// Para eliminar la ultima coma de una oracion conformada( , nombre1, nombre2, nombre3, ) 
        /// devolviendo algo como esto , nombre1, nombre2 y nombre3
        /// </summary>
        /// <param name="anOracion"></param>
        /// <returns></returns>
        public static string Acabado(this string anOracion)
        {
            int ultimaComaPos = anOracion.LastIndexOf(",");
            StringBuilder causaFinal = new StringBuilder(anOracion);//elimino coma si en la oracion la ultima letra es  una coma
            if (ultimaComaPos == -1) return "";
            if (anOracion.LastIndexOf(",") == anOracion.Length - 1)
            {
                if (causaFinal.Length > ultimaComaPos) causaFinal.Remove(ultimaComaPos, 1);
            }
            else
            {
                if (anOracion.IndexOf(",") == anOracion.LastIndexOf(","))
                {
                    //indica que solo hay una coma por lo tanto debe sustituirse por un espacio no por 'y'
                    causaFinal.Remove(anOracion.IndexOf(",", StringComparison.Ordinal), 1);
                }
                else
                {
                    if (GetLetraSiguiente(causaFinal, ultimaComaPos)=='i')
                        causaFinal[ultimaComaPos] = 'e';else
                        causaFinal[ultimaComaPos] = 'y';
                    if (causaFinal[ultimaComaPos] != ' ')
                        causaFinal.Insert(ultimaComaPos, " ");}


            }
            //Borro si queda una coma al principio
            if (causaFinal[0] == ',') {
                causaFinal.Remove(0, 1);
            }
            return causaFinal.ToString().Trim();
        }

        /// <summary>
        /// Devuelve una subcadena de la cadena eliminando a la derecha la cantidad de caracteres indicados en el argumento 
        /// </summary>
        /// <Author>Amilkar Ferrá</Author>
        /// <param name="anOracion"></param>
        /// <returns></returns>
        public static string Right(this string anOracion,int longitudAEliminar)
        {
            var subcadena = anOracion.Substring(0, anOracion.Count() - longitudAEliminar);
            return subcadena;
        }
        /// <summary>
        /// Devuelve la siguiente letra de una oracion a partir del indice indicado, obviando los espacios
        /// </summary>
        /// <param name="anOracion"></param>
        /// <param name="aPosicionDeLetra"></param>
        /// <returns>el caracter buscado, si es la ultima posicion devuelve vacio (" ")</returns>
        public static char GetLetraSiguiente(string anOracion, int aPosicionDeLetra)
        {
            StringBuilder oracionStringBuilder = new StringBuilder(anOracion);
            return GetLetraSiguiente(oracionStringBuilder, aPosicionDeLetra);}


        /// Devuelve la siguiente letra de una oracion a partir del indice indicado, obviando los espacios
        /// </summary>
        /// <param name="anOracion"></param>
        /// <param name="aPosicionDeLetra"></param>
        /// <returns>el caracter buscado, si es la ultima posicion devuelve vacio (" ")</returns>
        public static char GetLetraSiguiente(StringBuilder anOracion, int aPosicionDeLetra)
        {
            StringBuilder oracionStringBuilder = anOracion;
            var longitudOracion = anOracion.Length;
            for (var i = aPosicionDeLetra + 1; i < longitudOracion; i++)
            {
                if (oracionStringBuilder[i] != ' ')
                {
                    return oracionStringBuilder[i];
                }
            }
            return ' ';
        }

        

        /// <summary>
        /// Autor: Amilkar Ferrá
        /// Fecha: 22/03/2015
        /// </summary>
        /// <param name="aNombreCompleto">Nombre Completo </param>
        /// <example>Si se entra Amilkar Antonio Ferrá Díaz devuelve string[0]="Amilkar Antonio";string[1]="Ferrá" y string[2]="Díaz"</example>
        /// <returns></returns>
        public static string[] SplitNombreCompleto(this string aNombreCompleto)
        {

            string[] nombre = new string[3];
            var splitName = aNombreCompleto.Trim().Split(' '); 
            if (splitName.Length >= 3)
            {
                nombre[2] = (aNombreCompleto.Split(' ')[splitName.Length - 1]).Trim();
                nombre[1] = (aNombreCompleto.Split(' ')[splitName.Length - 2]).Trim();
                for (int i = 0; i < splitName.Length - 2; i++)
                {
                    nombre[0] += " " + aNombreCompleto.Split(' ')[i];
                }
                nombre[0] = nombre[0].Trim();
            }
            else if (splitName.Length == 2)
            {
                nombre[1] = splitName[1];
                nombre[0] = splitName[0];
            }
            else
            {
                nombre[0] = splitName[0].Trim();
            }
            return nombre;
        }

        public static string CleanInput(this string strIn)
        {
          return  Regex.Replace(strIn, @"[^0-9A-Za-z ]", "_", RegexOptions.None);
        }


    }

        #endregion Methods
}
