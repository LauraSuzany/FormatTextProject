using System.Text.RegularExpressions;

namespace FormatTextProject.Service
{
    public class ChangeTextService : IChangeTextService
    {
        public string HtmlToWhatsApp(string text) {

            List<string> listHtmlTagsText = new List<string>();
            string htmlTagsText = "<h1>,</h1>,<h2>,</h2>,<h3>,</h3>,<h4>,</h4>,<h5>,</h5>, " +
                "<h6>,</h6>,<pre>,</pre>,<blockquote>,</blockquote>,<br>,</br>,<mark>,</mark>, " +
                "<small>,</small>,<abbr>,</abbr>,<bdi>,</bdi>,<bdo>,</bdo>,<cite>,</cite>, " +
                "<dfn>,<dfn>,<ins>,</ins>,<kbd>,</kbd>,<label>,</label>,<legend>,</legend>, " +
                "<li>,</li>,<output>,</output>,<q>,</q>,<samp>,</samp>,<sub>,</sub>,<sup>, " +
                "</sup>,<time>,</time>,<u>,</u>,<var>,</var>,<wbr>,</wbr>,<big>,</big>, " +
                "<center>,</center>,<font>,</font>,<basefont>,</basefont>";

            List<string> newList = new List<string>();
            string markdown = Regex.Replace(text, "<b>", "*");//Negrito
            markdown = Regex.Replace(markdown, "</b>", "*");//Negrito
            markdown = Regex.Replace(markdown, "<strong>", "*");//Negrito
            markdown = Regex.Replace(markdown, "</strong>", "*");//Negrito
            markdown = Regex.Replace(markdown, "<i>", "_"); //itálico
            markdown = Regex.Replace(markdown, "</i>", "_");//itálico
            markdown = Regex.Replace(markdown, "<em>", "_");//itálico
            markdown = Regex.Replace(markdown, "</em>", "_");//itálico
            markdown = Regex.Replace(markdown, "<p>", ""); //tirar a tag de paragrafo
            markdown = Regex.Replace(markdown, "</p>", "");//tirar a tag de paragrafo
            markdown = Regex.Replace(markdown, "<s>", "~");//Strikethrough
            markdown = Regex.Replace(markdown, "</s>", "~"); //Strikethrough
            markdown = Regex.Replace(markdown, "<del>", "~"); //Strikethrough/Excluido
            markdown = Regex.Replace(markdown, "</del>", "~"); //Strikethrough/Excluido
            markdown = Regex.Replace(markdown, "<strike>", "~");//Strikethrough/Excluido
            markdown = Regex.Replace(markdown, "</strike>", "~");//Strikethrough/Excluido
            markdown = Regex.Replace(markdown, "<code>", "```"); //Monospace
            markdown = Regex.Replace(markdown, "</code>", "```");//Monospace
            markdown = Regex.Replace(markdown, "<pre>", "```");//Monospace
            markdown = Regex.Replace(markdown, "</pre>", "```");//Monospace
            markdown = Regex.Replace(markdown, "<tt>", "```");//Monospace
            markdown = Regex.Replace(markdown, "</tt>", "```");//Monospace

            htmlTagsText.Split(",").ToList().ForEach(x => listHtmlTagsText.Add(x));
            foreach (string tag in listHtmlTagsText)
            {
                if (text.Contains(tag))
                {
                    markdown = Regex.Replace(markdown, tag, "");//retirar todas as tags
                }
            }
          
            return markdown;
        }

        public string WhatsAppToHtml(string text)
        {
            string markdown = Regex.Replace(text, @"\*(.*?)\*", "<b>$1</b>");
            markdown = Regex.Replace(markdown, @"_(.*?)_", "<i>$1</i>");
            markdown = Regex.Replace(markdown, @"~(.*?)~", "<s>$1</s>");//Strikethrough
            markdown = Regex.Replace(markdown, @"```(.*?)```", "<code>$1</code>"); //Monospace  
            return markdown;
        }
    }
}
