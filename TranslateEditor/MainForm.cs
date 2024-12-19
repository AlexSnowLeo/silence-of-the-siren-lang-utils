using System.Xml;
using System;
using Microsoft.Extensions.Configuration;

namespace TranslateEditor
{
    public partial class MainForm : Form
    {
        private string _lang;
        private readonly string _langFolder;
        private string[] _files;

        public MainForm()
        {
            InitializeComponent();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            _lang = config.GetSection("Lang").Value ?? "RU";
            cbLang.SelectedItem = _lang;

            _langFolder = config.GetSection("LangFolder").Value ?? "data";
            toolStripStatusLabel1.Text = _langFolder;

            if (!Directory.Exists(_langFolder))
            {
                MessageBox.Show(
                    $"Directory not found: '{_langFolder}'\n\n" +
                    $"Please specify it in the appsettings.json");

                return;
            }

            _files = Directory.GetFiles(Path.Combine(_langFolder, "localization-base-english"), "*.xml");

            cbFiles.Items.Clear();
            foreach (var f in _files)
            {
                cbFiles.Items.Add(Path.GetFileName(f));
            }
        }

        private void cbFiles_SelectedChanged(object sender, EventArgs e)
        {

        }

        private XmlDocument _langDoc;
        private string _langFileName;
        private void cbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileText = cbFiles.SelectedItem as string;
            if (string.IsNullOrEmpty(fileText))
                return;

            var fileName = Path.Combine(_langFolder, "localization-base-english", fileText);

            var lang = _lang.ToLower();
            var capLang = lang[0].ToString().ToUpper() + lang[1];
            _langFileName = Path.Combine(_langFolder, $"localization-pack-{lang}", fileText.Replace("StringTableEn", $"StringTable{capLang}"));

            var backFileName = Path.Combine("backup", $"localization-pack-{lang}", Path.GetFileName(_langFileName));
            if (!File.Exists(backFileName))
            {
                var backDir = Path.GetDirectoryName(backFileName);
                if (!Directory.Exists(backDir))
                    Directory.CreateDirectory(backDir!);

                File.Copy(_langFileName, backFileName);
            }


            var enDoc = new XmlDocument();
            enDoc.Load(fileName);

            _langDoc = new XmlDocument();
            _langDoc.Load(_langFileName);

            if (enDoc.DocumentElement != null && _langDoc.DocumentElement != null)
            {
                var localizedStrings = enDoc.DocumentElement.GetElementsByTagName("LocalizedStrings")[0]?.SelectNodes("GameDBLocalizedString");
                if (localizedStrings == null)
                    return;

                //var localizedStrings = xDoc.DocumentElement.SelectNodes("GameDBLocalizedString");

                gridLang.RowCount = localizedStrings.Count;

                var i = 0;
                foreach (XmlElement ls in localizedStrings)
                {
                    var locId = ls.SelectSingleNode("LocID")?.InnerText;
                    var langValue = _langDoc.DocumentElement
                        .SelectSingleNode($"//GameDBStringTable/LocalizedStrings/GameDBLocalizedString/LocID[text()='{locId}']")?
                        .ParentNode?
                        .SelectSingleNode("Text")?.InnerXml;

                    var enValue = ls.SelectSingleNode("Text")?.InnerXml;

                    gridLang.Rows[i].Cells[0].Value = locId;
                    gridLang.Rows[i].Cells[1].Value = enValue;
                    gridLang.Rows[i].Cells[2].Value = langValue;

                    gridLang.Rows[i].Cells[2].Style.BackColor = enValue != langValue && !string.IsNullOrEmpty(langValue)
                        ? Color.LightGreen
                        : Color.LightCoral;

                    i++;
                }

            }
        }

        private void gridLang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_langDoc?.DocumentElement == null)
                return;

            if (e.ColumnIndex != 2)
                return;

            var locId = gridLang.Rows[e.RowIndex].Cells[0].Value;

            var langNode = _langDoc.DocumentElement
                .SelectSingleNode($"//GameDBStringTable/LocalizedStrings/GameDBLocalizedString/LocID[text()='{locId}']")?
                .ParentNode?
                .SelectSingleNode("Text");

            if (langNode == null)
                return;

            var langValue = gridLang.Rows[e.RowIndex].Cells[2].Value as string ?? string.Empty;
            var enValue = gridLang.Rows[e.RowIndex].Cells[1].Value as string ?? string.Empty;
            langNode.InnerXml = langValue;

            gridLang.Rows[e.RowIndex].Cells[2].Style.BackColor = enValue != langValue && !string.IsNullOrEmpty(langValue)
                ? Color.LightGreen
                : Color.LightCoral;

            _langDoc.Save(_langFileName);
        }

        private int _searchRow;
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var search = tbSearch.Text;
            if (string.IsNullOrEmpty(search))
                return;

            if (e.KeyChar == (char)13)
            {
                for (int i = _searchRow + 1; i < gridLang.RowCount; i++)
                {
                    if (gridLang.Rows[i].Cells[0].Value.ToString().Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        gridLang.Rows[i].Cells[0].Selected = true;
                        _searchRow = i;
                        gridLang.FirstDisplayedScrollingRowIndex = i;

                        return;
                    }

                    if (gridLang.Rows[i].Cells[1].Value.ToString().Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        gridLang.Rows[i].Cells[1].Selected = true;
                        _searchRow = i;
                        gridLang.FirstDisplayedScrollingRowIndex = i;

                        return;
                    }

                    if (gridLang.Rows[i].Cells[2].Value.ToString().Contains(search, StringComparison.InvariantCultureIgnoreCase))
                    {
                        gridLang.Rows[i].Cells[2].Selected = true;
                        _searchRow = i;
                        gridLang.FirstDisplayedScrollingRowIndex = i;

                        return;
                    }
                }

                _searchRow = 0;
            }
        }

        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLang.SelectedItem == null)
                return;

            _lang = cbLang.SelectedItem as string;

            if (!string.IsNullOrEmpty(_langFileName))
            {
                cbFiles_SelectedIndexChanged(sender, e);
            }
        }
    }
}
