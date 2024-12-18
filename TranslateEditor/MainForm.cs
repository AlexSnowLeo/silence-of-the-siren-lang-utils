using System.Xml;
using System;
using Microsoft.Extensions.Configuration;

namespace TranslateEditor
{
    public partial class MainForm : Form
    {
        private readonly string _langFolder;
        private string[] _files;

        public MainForm()
        {
            InitializeComponent();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

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

        private XmlDocument _ruDoc;
        private string _ruFileName;
        private void cbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileText = cbFiles.SelectedItem as string;
            if (string.IsNullOrEmpty(fileText))
                return;

            var fileName = Path.Combine(_langFolder, "localization-base-english", fileText);

            _ruFileName = Path.Combine(_langFolder, "localization-pack-ru", fileText.Replace("StringTableEn", "StringTableRu"));

            var backFileName = Path.Combine("backup", "localization-pack-ru", Path.GetFileName(_ruFileName));
            if (!File.Exists(backFileName))
            {
                var backDir = Path.GetDirectoryName(backFileName);
                if (!Directory.Exists(backDir))
                    Directory.CreateDirectory(backDir!);

                File.Copy(_ruFileName, backFileName);
            }


            var enDoc = new XmlDocument();
            enDoc.Load(fileName);

            _ruDoc = new XmlDocument();
            _ruDoc.Load(_ruFileName);

            if (enDoc.DocumentElement != null && _ruDoc.DocumentElement != null)
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
                    var ruValue = _ruDoc.DocumentElement
                        .SelectSingleNode($"//GameDBStringTable/LocalizedStrings/GameDBLocalizedString/LocID[text()='{locId}']")?
                        .ParentNode?
                        .SelectSingleNode("Text")?.InnerXml;

                    var enValue = ls.SelectSingleNode("Text")?.InnerXml;

                    gridLang.Rows[i].Cells[0].Value = locId;
                    gridLang.Rows[i].Cells[1].Value = enValue;
                    gridLang.Rows[i].Cells[2].Value = ruValue;

                    gridLang.Rows[i].Cells[2].Style.BackColor = enValue != ruValue && !string.IsNullOrEmpty(ruValue)
                        ? Color.LightGreen
                        : Color.LightCoral;

                    i++;
                }

            }
        }

        private void gridLang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_ruDoc?.DocumentElement == null)
                return;

            if (e.ColumnIndex != 2)
                return;

            var locId = gridLang.Rows[e.RowIndex].Cells[0].Value;

            var ruNode = _ruDoc.DocumentElement
                .SelectSingleNode($"//GameDBStringTable/LocalizedStrings/GameDBLocalizedString/LocID[text()='{locId}']")?
                .ParentNode?
                .SelectSingleNode("Text");

            if (ruNode == null)
                return;

            var ruValue = gridLang.Rows[e.RowIndex].Cells[2].Value as string ?? string.Empty;
            var enValue = gridLang.Rows[e.RowIndex].Cells[1].Value as string ?? string.Empty;
            ruNode.InnerXml = ruValue;

            gridLang.Rows[e.RowIndex].Cells[2].Style.BackColor = enValue != ruValue && !string.IsNullOrEmpty(ruValue)
                ? Color.LightGreen
                : Color.LightCoral;

            _ruDoc.Save(_ruFileName);
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
    }
}
