using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Datos;
using Entidad;

namespace Negocio
{
    public class nUsuarios
    {
        dUsuarios dusuarios=new dUsuarios();
        public string Insertar(string Nombresapellidos,string DNI,string Telefono,string Correo,string Distrito,string Situacionlaboral,string Descripcion,string L1,string L2,string L3,string L4,string C1,string C2,string C3,string C4,byte[] Foto,int Valoracion,int P1,int P2,int P3, string Link)
        {
            eUsuarios e=new eUsuarios() 
            {
                Nombresapellidos=Nombresapellidos,
                DNI=DNI,
                Telefono=Telefono, 
                Correo=Correo, 
                Distrito=Distrito,
                Situacionlaboral=Situacionlaboral,
                Descripcion=Descripcion,
                L1=L1,
                L2=L2,
                L3=L3,
                L4=L4,
                C1=C1,
                C2=C2,
                C3=C3,
                C4=C4,
                Foto=Foto,
                Valoracion=Valoracion,
                P1 = P1,
                P2 = P2,
                P3 = P3,
                Link=Link

            };
            return dusuarios.Insertar(e);
        }
        public byte[] VerFoto(int Codigo)
        {
            eUsuarios e = new eUsuarios { Codigo = Codigo };
            return dusuarios.VerFoto(e);
        }
        public string Puntuar(int Valoracion,int Codigo)
        {
            eUsuarios e = new eUsuarios { Valoracion=Valoracion,Codigo = Codigo };
            return dusuarios.Puntuar(e);
        }
        public string Eliminar(int Codigo)
        {
            eUsuarios e = new eUsuarios { Codigo = Codigo };
            return dusuarios.Eliminar(e);
        }
        public string Modificar(int Codigo,string Nombresapellidos, string DNI, string Telefono, string Correo, string Distrito, string Situacionlaboral)
        {
            eUsuarios e = new eUsuarios {
                Codigo = Codigo,
                Nombresapellidos = Nombresapellidos,
                DNI=DNI,
                Telefono= Telefono,
                Correo= Correo,
                Distrito= Distrito,
                Situacionlaboral= Situacionlaboral 
            };
            return dusuarios.Modificar(e);
        }
        public List<eUsuarios> BuscarDis(string Distrito)
        {
            eUsuarios e=new eUsuarios { Distrito = Distrito };
            return dusuarios.BuscarDis(e);
        }
        public List<eUsuarios> Buscarc(string t)
        {
            return dusuarios.Buscarc(t);
        }
        public List<eUsuarios> Listarpunt()
        {
            return dusuarios.Listarpunt();
        }
       
        public List<eUsuarios> Listar()
        {
            return dusuarios.Listar();
        }

    }
}

