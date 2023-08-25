using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;

namespace MVC02.TagHelpers
{
    public class IzinTalepTagHelper : TagHelper
    {
        
            public IzinTalep Talep { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
               
                output.TagName = "tr"; // Tablo satırını temsil eden <tr> etiketi oluştur
            output.Attributes.Add("class", "TalepAsamaTr");
                // Tablo satırı içeriği oluştur
                output.Content.AppendHtml($"<td>{Talep.IzinTalepId}</td>");
                output.Content.AppendHtml($"<td>{Talep.IzinBaslangicTarihi}</td>");
                output.Content.AppendHtml($"<td>{Talep.IzinBitisTarihi}</td>");

            if (Talep.TalepAsama == ETalepAsama.BEKLIYOR)
            {
                var selectList = new List<SelectListItem>();
                foreach (ETalepAsama enumValue in Enum.GetValues(typeof(ETalepAsama)))
                {
                    var listItem = new SelectListItem
                    {
                        Text = enumValue.ToString(),
                        Value = ((int)enumValue).ToString()
                    };
                    selectList.Add(listItem);
                }
                var selectBox = new TagBuilder("select");
                selectBox.Attributes.Add("class", "TalepAsama");
                foreach(var item in selectList)
                {
                    var option = new TagBuilder("option");
                    option.InnerHtml.AppendHtml(item.Text);
                    option.Attributes.Add("value", item.Value);
                    selectBox.InnerHtml.AppendHtml(option);
                }

                output.Content.AppendHtml("<td>");
                output.Content.AppendHtml(selectBox);
                output.Content.AppendHtml("</td>");

            }
            else
            {
                output.Content.AppendHtml($"<td>{Talep.TalepAsama}</td>");
            }
                output.Content.AppendHtml($"<td>{Talep.IzinAciklama}</td>");
            var td = new TagBuilder("td");
            td.Attributes.Add("data-calisanid", Talep.CalisanId.ToString());
            td.InnerHtml.AppendHtml(Talep.CalisanId.ToString());
            output.Content.AppendHtml(td);
                var button = new TagBuilder("button");
               button.Attributes.Add("class", "talepKayit");
               button.InnerHtml.AppendHtml("Kaydet");
               output.Content.AppendHtml("<td>");
               output.Content.AppendHtml(button);
               output.Content.AppendHtml("</td>");
  

        }
        }
    }

