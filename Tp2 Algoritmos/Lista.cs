using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp2_Algoritmos
{
    public class Lista
    {
        public Turno centinela;

        public Lista()
        {
            centinela = null;
        }

        public void NuevoTurno( string nombre)   //si no se le pone posicion se agrega primero
        {
            int pos = 0; 
                Turno reco = new Turno();
                Turno nuevo = new Turno();
               
                nuevo.nombre = nombre;
                pos = Cantidad();
                nuevo.posicion = pos;

            if (pos == 0) {
               
                centinela = nuevo;   
            
            }


            else if (pos == 1)
                {
                    nuevo.siguiente = centinela;
                    centinela.anterior = nuevo;
                    centinela = nuevo;
                }
                
                else if (pos >1)
                {
                     reco = centinela;
                    while (reco.siguiente != null)
                    {
                        reco = reco.siguiente;
                    }
                    reco.siguiente = nuevo;
                    nuevo.siguiente = reco;
                    nuevo.siguiente = null;
                }
                
            
        }

       

        public string BorrarTurno(string nombre)
        {
           
            Turno reco = centinela;
            bool flag = false;
            int pos = 0;

            if (nombre == "ultimo")
            {
                pos = Cantidad();

            }

            else
            {
                while (reco != null)
                {




                    //Console.Write(reco.posicion + "-");
                    if (reco.nombre == nombre) { flag = true; break; }


                    reco = reco.siguiente;

                }


                if (flag == false) { return "nombre no encontrado"; }


                else { pos = reco.posicion; }

            }

            if (pos <= Cantidad())
            {
                if (pos == 1)
                {
                    centinela = centinela.siguiente;
                    if (centinela != null)
                       centinela.anterior = null;
                }
                else
                {
                    
                    reco = centinela;
                    for (int f = 1; f <= pos - 2; f++)
                        reco = reco.siguiente;
                    Turno prox = reco.siguiente;
                    try
                    {
                        prox = prox.siguiente;
                        reco.siguiente = prox;
                        if (prox != null)
                            prox.anterior = reco;
                    }
                    catch { return $"el turno de {nombre} se borró exitosamente"; }
                }
            }
            return $"el turno de {nombre} se borró exitosamente";
        }

        public void Intercambiar(int pos1, int pos2)
        {
            if (pos1 <= Cantidad() && pos2 <= Cantidad())
            {
                Turno reco1 = centinela;
                for (int f = 1; f < pos1; f++)
                    reco1 = reco1.siguiente;
                Turno reco2 = centinela;
                for (int f = 1; f < pos2; f++)
                    reco2 = reco2.siguiente;
                int aux = reco1.posicion;
                reco1.posicion = reco2.posicion;
                reco2.posicion = aux;
            }
        }

        public int Mayor()
        {
            if (!Vacia())
            {
                int may = centinela.posicion;
                Turno reco = centinela.siguiente;
                while (reco != null)
                {
                    if (reco.posicion > may)
                        may = reco.posicion;
                    reco = reco.siguiente;
                }
                return may;
            }
            else
                return int.MaxValue;
        }

        public int PosMayor()
        {
            if (!Vacia())
            {
                int may = centinela.posicion;
                int x = 1;
                int pos = x;
                Turno reco = centinela.siguiente ;
                while (reco != null)
                {
                    if (reco.posicion > may)
                    {
                        may = reco.posicion;
                        pos = x;
                    }
                    reco = reco.siguiente;
                    x++;
                }
                return pos;
            }
            else
                return int.MaxValue;
        }

        public int Cantidad()
        {
            int cant = 0;
            Turno reco = centinela;
            while (reco != null)
            {
                reco = reco.siguiente;
                cant++;
            }
            return cant;
        }

       
        public bool Existe(int x)
        {
            Turno reco = centinela;
            while (reco != null)
            {
                if (reco.posicion == x)
                    return true;
                reco = reco.siguiente;
            }
            return false;
        }

        public bool Vacia()
        {
            if (centinela == null)
                return true;
            else
                return false;
        }

        public List<Turno> Retornalista()
        {
            Turno reco = centinela;

            List<Turno> retornalista = new List<Turno>();
            while (reco != null)
            {
               
                    retornalista.Add(reco);

                    reco = reco.siguiente;
              }
            return retornalista;
        }

       


    }
}
