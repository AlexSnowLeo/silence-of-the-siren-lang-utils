using System.Xml;

namespace TranslateEditor
{
    public partial class SearchForm : Form
    {
        private string _lang;
        private string _langFolder;

        public class DoubleClickFileEventArgs(string file, string? locID) : EventArgs
        {
            public string File { get; } = file;
            public string? LocID { get; } = locID;
        }

        public event EventHandler<DoubleClickFileEventArgs>? OnDoubleClickFile;

        public SearchForm(string lang, string langFolder, string searchText)
        {
            _lang = lang;
            _langFolder = langFolder;

            InitializeComponent();

            tbSearch.Text = searchText;
            btnSearch_Click(this, new EventArgs());
        }

        private class SearchItem
        {
            public SearchItem(string fileName, string? locID, string? enValue, string? langValue)
            {
                FileName = fileName;
                LocID = locID;
                EnValue = enValue;
                LangValue = langValue;
            }

            public string FileName { get; set; }
            public string? LocID { get; set; }
            public string? EnValue { get; set; }
            public string? LangValue { get; set; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length < 3)
                return;

            var files = Directory.GetFiles(Path.Combine(_langFolder, "localization-base-english"), "*.xml");

            var searchItems = new List<SearchItem>();
            foreach (var file in files)
            {
                var lang = _lang.ToLower();
                var capLang = lang[0].ToString().ToUpper() + lang[1];
                var langFile = file
                    .Replace("localization-base-english", $"localization-pack-{lang}")
                    .Replace("StringTableEn", $"StringTable{capLang}");

                var enDoc = new XmlDocument();
                enDoc.Load(file);

                var langDoc = new XmlDocument();
                langDoc.Load(langFile);

                if (enDoc.DocumentElement != null && langDoc.DocumentElement != null)
                {
                    var localizedStrings = enDoc.DocumentElement.GetElementsByTagName("LocalizedStrings")[0]?.SelectNodes("GameDBLocalizedString");
                    if (localizedStrings == null)
                        return;

                    foreach (XmlElement ls in localizedStrings)
                    {
                        var locId = ls.SelectSingleNode("LocID")?.InnerText;
                        var langValue = langDoc.DocumentElement
                            .SelectSingleNode($"//GameDBStringTable/LocalizedStrings/GameDBLocalizedString/LocID[text()='{locId}']")?
                            .ParentNode?
                            .SelectSingleNode("Text")?.InnerXml;

                        var enValue = ls.SelectSingleNode("Text")?.InnerXml;

                        if (locId != null && locId.Contains(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) ||
                            enValue != null && enValue.Contains(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) ||
                            (langValue != enValue && (langValue?.Contains(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) ?? false)))
                        {
                            var fileName = Path.GetFileName(file);
                            searchItems.Add(new SearchItem(fileName, locId, enValue, langValue));
                        }
                    }
                }
            }

            var i = 0;
            lbSearchCount.Text = $"Search count: {searchItems.Count}";
            gridLang.RowCount = searchItems.Count;
            foreach (var item in searchItems)
            {
                gridLang.Rows[i].Cells[0].Value = item.FileName;
                gridLang.Rows[i].Cells[1].Value = item.LocID;
                gridLang.Rows[i].Cells[2].Value = item.EnValue;
                gridLang.Rows[i].Cells[3].Value = item.LangValue;

                if (item.EnValue?.Trim() == item.LangValue?.Trim() && !string.IsNullOrWhiteSpace(item.LangValue))
                    gridLang.Rows[i].Cells[3].Style.BackColor = Color.LightCoral;

                i++;
            }
        }

        private void gridLang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;

            var file = gridLang.Rows[e.RowIndex].Cells[0].Value as string;
            var locID = gridLang.Rows[e.RowIndex].Cells[1].Value as string;
            if (string.IsNullOrEmpty(file))
                return;

            OnDoubleClickFile?.Invoke(this, new DoubleClickFileEventArgs(file, locID));
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
