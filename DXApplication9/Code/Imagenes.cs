using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DXApplication9
{
    public partial class Imagenes
    {
        public static int Salvar(byte[] anImagen, string aDescripcion, int anArrange, NegocioDataContext aNegocioDataContext = null)
        {
            NegocioDataContext dataContext = aNegocioDataContext ?? new NegocioDataContext();
            Imagenes imagen = new Imagenes
            {
                Imagen = anImagen,
                Descripcion = aDescripcion,
                Orden = anArrange
            };
            dataContext.Imagenes.InsertOnSubmit(imagen);
            dataContext.SubmitChanges();
            return imagen.ImagenID;
        }

        public static int Salvar(Image anImagen, string aDescripcion, int anArrange, NegocioDataContext aNegocioDataContext = null)
        {
            Binary binary ;
            using (MemoryStream ms = new MemoryStream())
            {
                anImagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                binary = new Binary(ms.GetBuffer());
                byte[] imagen = binary.ToArray();
                return Salvar(imagen, aDescripcion, anArrange, aNegocioDataContext);
            }
        }



        public Bitmap BitmapImagen
        {
            get
            {
                if (Imagen != null)
                {
                    byte[] pictBinary = this.Imagen.ToArray();
                    MemoryStream ms = new MemoryStream(pictBinary);
                    Bitmap imagenBitmap = new Bitmap(ms);
                    return imagenBitmap;
                }
                return null;
            }

        }

        
    }
}
