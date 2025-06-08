namespace PreventPlus.DTOs
{
    public class ChecklistDTO
    {
        public int IdChecklist { get; set; }
        public string TituloChecklist { get; set; }
        public string DescricaoChecklist { get; set; }
        public string StatusChecklist { get; set; }
        public int IdUsuario { get; set; }
    }
}