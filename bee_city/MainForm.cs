using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using bee_city.Classes;
using bee_city.Enums;

namespace bee_city
{
    public partial class MainForm : Form
    {
        private BeeCity beeCity;
        public MainForm()
        {
            InitializeComponent();
        }
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите JSON файл с данными пасеки";
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonPath = openFileDialog.FileName;

                try
                {
                    string json = File.ReadAllText(jsonPath);
                    var wrapper = JsonConvert.DeserializeObject<Dictionary<string, BeeCity>>(json);
                    beeCity = wrapper["BeeCity"];
                    BuildTree();
                    MessageBox.Show($"Данные успешно загружены!\n\nФайл: {Path.GetFileName(jsonPath)}",
                                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла:\n{ex.Message}",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuildTree()
        {
            TreeNode root = new TreeNode("Пасека");
            root.Tag = beeCity;

            //Узлы ульев
            TreeNode housesNode = new TreeNode("Ульи");
            foreach (var house in beeCity.BeesHouses)
            {
                TreeNode houseNode = new TreeNode($"Улей {house.HouseNumber}");
                houseNode.Tag = house;

                //Семья
                TreeNode familyNode = new TreeNode(house.BeeFamily.FamilyName);
                familyNode.Tag = house.BeeFamily;

                //Пчёлы
                foreach (var bee in house.BeeFamily.Bees)
                {
                    TreeNode beeNode = new TreeNode(bee.BeeName);
                    beeNode.Tag = bee;
                    familyNode.Nodes.Add(beeNode);
                }

                houseNode.Nodes.Add(familyNode);
                housesNode.Nodes.Add(houseNode);
            }

            root.Nodes.Add(housesNode);
            treeView.Nodes.Add(root);
            treeView.ExpandAll();
        }
        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            if (beeCity == null)
            {
                MessageBox.Show("Сначала загрузите данные!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (treeView.SelectedNode?.Tag == null)
            {
                MessageBox.Show("Выберите элемент в дереве",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ShowInfoInTable(treeView.SelectedNode.Tag);
        }

        private void ShowInfoInTable(object item)
        {
            showTable.Rows.Clear();
            showTable.Columns.Clear();

            if (item is BeeCity city)
            {
                showTable.Columns.Add("Property", "Свойство");
                showTable.Columns.Add("Value", "Значение");
                showTable.Rows.Add("Название", city.Name);
                showTable.Rows.Add("Владелец", city.Owner);
                showTable.Rows.Add("Город", city.Address.City);
                showTable.Rows.Add("Улица", city.Address.Street);
                showTable.Rows.Add("Участок", city.Address.PlotNumber);
                showTable.Rows.Add("Количество ульев", city.BeesHouses.Count);
                showTable.Rows.Add("Дата основания", city.DateOfFoundation.ToString("yyyy-MM-dd"));
            }
            else if (item is BeeHouse house)
            {
                showTable.Columns.Add("Property", "Свойство");
                showTable.Columns.Add("Value", "Значение");
                showTable.Rows.Add("Номер улья", house.HouseNumber);
                showTable.Rows.Add("Тип", GetHouseTypeText(house.HouseType));
                showTable.Rows.Add("Состояние", GetConditionText(house.Condition));
                showTable.Rows.Add("Длина", $"{house.Dimension.Length} мм");
                showTable.Rows.Add("Ширина", $"{house.Dimension.Width} мм");
                showTable.Rows.Add("Высота", $"{house.Dimension.Height} мм");
                showTable.Rows.Add("Семья", house.BeeFamily.FamilyName);
                showTable.Rows.Add("Мёда за сезон", $"{house.BeeFamily.HoneyHarvest} кг");
            }
            else if (item is BeeFamily family)
            {
                showTable.Columns.Add("Property", "Свойство");
                showTable.Columns.Add("Value", "Значение");
                showTable.Rows.Add("ID семьи", family.FamilyID);
                showTable.Rows.Add("Название", family.FamilyName);
                showTable.Rows.Add("Тип", GetFamilyTypeText(family.FamilyType));
                showTable.Rows.Add("Количество пчёл", family.Bees.Count);
                showTable.Rows.Add("Мёда за сезон", $"{family.HoneyHarvest} кг");
            }
            else if (item is Bee bee)
            {
                showTable.Columns.Add("Property", "Свойство");
                showTable.Columns.Add("Value", "Значение");
                showTable.Rows.Add("ID пчелы", bee.BeeID);
                showTable.Rows.Add("Имя", bee.BeeName);
                showTable.Rows.Add("Роль", GetBeeRoleText(bee.BeeRole));
                showTable.Rows.Add("Начало работы", bee.BeeSchedule.WorkStart.ToString(@"hh\:mm"));
                showTable.Rows.Add("Конец работы", bee.BeeSchedule.WorkEnd.ToString(@"hh\:mm"));
                showTable.Rows.Add("Хобби", bee.BeeHobby.HobbyName);
                showTable.Rows.Add("Часов в неделю", bee.BeeHobby.TimePerWeek);
            }
        }
        private string GetHouseTypeText(HouseType type)
        {
            switch (type)
            {
                case HouseType.SingleHull: return "Однокорпусный";
                case HouseType.DoubleHull: return "Двухкорпусный";
                default: return type.ToString();
            }
        }

        private string GetConditionText(Condition condition)
        {
            switch (condition)
            {
                case Condition.Good: return "Хорошее";
                case Condition.Normal: return "Среднее";
                case Condition.Bad: return "Плохое";
                default: return condition.ToString();
            }
        }

        private string GetFamilyTypeText(FamilyType type)
        {
            switch (type)
            {
                case FamilyType.Sloggers: return "Трудяги";
                case FamilyType.Average: return "Среднестатистическая";
                case FamilyType.Loafers: return "Балдежники";
                default: return type.ToString();
            }
        }

        private string GetBeeRoleText(BeeRole role)
        {
            switch (role)
            {
                case BeeRole.Queen: return "Матка";
                case BeeRole.Drone: return "Трутень";
                case BeeRole.Worker: return "Рабочая";
                default: return role.ToString();
            }
        }
        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            showTable.Rows.Clear();
            showTable.Columns.Clear();
        }
    }
}
