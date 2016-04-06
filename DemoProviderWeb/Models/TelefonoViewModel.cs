using Microsoft.SharePoint.Client;

namespace DemoProviderWeb.Models
{
    public class TelefonoViewModel
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Numero { get; set; }

        public static TelefonoViewModel FromListItem(ListItem item)
        {
            var data = new TelefonoViewModel();
            var id = item["ID"].ToString();
            var ido = 0;
            int.TryParse(id, out ido);
            data.Id = ido;
            data.Nombre = item["Title"].ToString(); //Ese "Title" es el nombre de la columna. Se comprueba en la ruta de enlace en el sitio web
            data.Numero = item["Numero"].ToString(); //Ese "Title" es el nombre de la columna. Se comprueba en la ruta de enlace en el sitio web
            return data;
        }
    }
}