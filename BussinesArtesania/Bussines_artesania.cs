using DataArtesania;
using EntityArtesanias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesArtesania
{
    public class Bussines_artesania
    {
        Data_artesania data = new Data_artesania();

        public List<Entity_artesania> Obtener()
        {
            DataTable  lista_artesania = data.Obtener();
            List<Entity_artesania> lista = new List<Entity_artesania>();    

        }
    }
}
