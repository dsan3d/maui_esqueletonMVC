using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_esqueletonMVC.Views;
using maui_esqueletonMVC.Services;
using maui_esqueletonMVC.Models;
     

namespace maui_esqueletonMVC.ViewModels
{
    
    internal class VentanaUnoVM
    {
        public string MyLabel { get; set; }
        public Command BtnPulsar { get; set; }


        public VentanaUnoVM() {
            MyLabel = "HOLA MUNDO";

            BtnPulsar = new Command(() => CambiarTexto());


        }

        private void CambiarTexto()
        {
            MyLabel = "He pulsado el boton";
        }
    }
}
