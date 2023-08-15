using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataBinding
{
    //hacemos la clase alumno, y con INotifyPropertyChanged se notificara el cambio que se hizo
    public class Alumno:INotifyPropertyChanged
    {
        //Cada vez que se haga un cambio, se notificara 
        public event PropertyChangedEventHandler PropertyChanged;
        //esto almacenara el nombre
        string nombre = string.Empty;


        public string Nombre
        {
            //devuelve el valor actual almacenado
            get => nombre;
            //cuando se quiera asignar un nuevo valor a la propiedad nombre se mostrara dentro de este bloque
            set
            {
                //esto verificara si el nuevo valor es igual al valor actual de nombre
                if (nombre == value)
                    return;
                //si el valor es diferente se actualizara al nuevo valor
                nombre = value;
                //Esto notificara el cambio a la propiedad nombre
                onPropertyChanged(nameof(Nombre));
            //tambien se le notifica a la propiedad nombre
                onPropertyChanged(nameof(MostrarNombre));
            }
        }
        //esto mostrara el nombre ingresado
        public string MostrarNombre=>$"Nombre ingresado:{Nombre}";
        //llama la propiedad PropertyChanged, para que notifique el cambio
        void onPropertyChanged(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
