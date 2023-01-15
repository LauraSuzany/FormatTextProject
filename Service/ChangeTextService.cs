using System.Text.RegularExpressions;
using System.Web;

namespace FormatTextProject.Service
{
    public class ChangeTextService : IChangeTextService
    {
        public string HtmlToWhatsApp(string text) {

            string markdown = Regex.Replace(text, "<b>", "*");//Negrito
            markdown = Regex.Replace(markdown, "</b>", "*");//Negrito
            markdown = Regex.Replace(markdown, "<i>", "_"); //itálico
            markdown = Regex.Replace(markdown, "</i>", "_");//itálico
            markdown = Regex.Replace(markdown, "<p>", ""); //tirar a tag de paragrafo
            markdown = Regex.Replace(markdown, "</p>", "");//tirar a tag de paragrafo
            markdown = Regex.Replace(markdown, "<s>", "~");//Strikethrough
            markdown = Regex.Replace(markdown, "</s>", "~"); //Strikethrough
            markdown = Regex.Replace(markdown, "<code>", "```"); //Monospace
            markdown = Regex.Replace(markdown, "</code>", "```");//Monospace
            markdown = Regex.Replace(markdown, "<pre>", "```");//Monospace
            markdown = Regex.Replace(markdown, "</pre>", "```");//Monospace
            return markdown;
        }

        public string WhatsAppToHtml(string text)
        {

            string markdown = Regex.Replace(text, @"\*", "<b>");//Negrito
            markdown = Regex.Replace(markdown, @"\*", "</b>");//Negrito
            markdown = Regex.Replace(markdown, "_", "<i>"); //itálico
            markdown = Regex.Replace(markdown, "_", "</i>");//itálico
            markdown = Regex.Replace(markdown, "~", "<s>");//Strikethrough
            markdown = Regex.Replace(markdown, "~", "</s>"); //Strikethrough
            markdown = Regex.Replace(markdown, "```", "<code>"); //Monospace
            markdown = Regex.Replace(markdown, "```", "<.code>"); //Monospace
            markdown = Regex.Replace(markdown, "```", "<pre>");//Monospace
            markdown = Regex.Replace(markdown, "```", "</pre>");//Monospace
            return markdown;
        }
    }
}
