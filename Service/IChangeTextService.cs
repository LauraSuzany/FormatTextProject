namespace FormatTextProject.Service
{
    public interface IChangeTextService
    {
        string HtmlToWhatsApp(string text);
        public string WhatsAppToHtml(string text);
    }
}
