using Driver_Tool.Dialog;
using Driver_Tool.Manager;
using MQTT_Protocol.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Driver_Tool
{
    public partial class frm_TagManagement : Form
    {
        private bool IsDataChanged = false;

        public frm_TagManagement()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frm_TagManagement_Load(object sender, EventArgs e)
        {
            try
            {
                string xmlFile = Building_Manager.ReadKey(Building_Manager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeData(Building_Manager.ReadKey(Building_Manager.XML_NAME_DEFAULT));
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeData(string xmlPath)
        {
            Building_Manager.Buildings.Clear();
            Building_Manager.XmlPath = xmlPath;
            List<Building> buildingList = Building_Manager.GetBuildings();
            treeView1.Nodes.Clear();

            foreach (Building building in buildingList)
            {
                List<TreeNode> floorList = new List<TreeNode>();
                building.Floors.Sort(delegate (Floor x, Floor y)
                {
                    return x.FloorName.CompareTo(y.FloorName);
                });

                foreach (Floor floor in building.Floors)
                {
                    List<TreeNode> roomList = new List<TreeNode>();
                    foreach (Room room in floor.Rooms)
                    {
                        List<TreeNode> tagList = new List<TreeNode>();
                        foreach (Device device in room.Devices)
                        {
                            tagList.Add(new TreeNode(device.DeviceName));
                        }

                        TreeNode roomNode = new TreeNode(room.RoomName, tagList.ToArray());
                        roomList.Add(roomNode);
                    }

                    TreeNode floorNode = new TreeNode(floor.FloorName, roomList.ToArray());
                    floorList.Add(floorNode);
                }

                TreeNode buildingNode = new TreeNode(building.BuildingName, floorList.ToArray());
                treeView1.Nodes.Add(buildingNode);
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            try
            {
                Building_Manager.CreatFile(string.Format("{0}\\{1}.xml", Application.StartupPath, Building_Manager.XML_NAME_DEFAULT));
                treeView1.Nodes.Clear();
                listView1.Items.Clear();
                Building_Manager.Buildings.Clear();
                IsDataChanged = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            try
            {
                // Show the dialog and get result.
                openFileDialog1.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog1.FileName = "config";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    InitializeData(openFileDialog1.FileName);
                    IsDataChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Building_Manager.XmlPath) || string.IsNullOrWhiteSpace(Building_Manager.XmlPath))
                {
                    Building_Manager.Save(string.Format("{0}\\{1}.xml", Application.StartupPath, Building_Manager.XML_NAME_DEFAULT));
                }
                else
                {
                    Building_Manager.Save(Building_Manager.XmlPath);
                    MessageBox.Show(this, "Data saved successfully!", Msg.MSG_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.FileName = Building_Manager.XML_NAME_DEFAULT;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string xmlPath = saveFileDialog1.FileName;
                    Building_Manager.Save(xmlPath);
                    IsDataChanged = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Building_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Building chFrm = new frm_Building();
                chFrm.eventBuildingChanged += new EventBuildingChanged((ch) =>
                {
                    try
                    {
                        TreeNode newNode = treeView1.Nodes.Add(ch.BuildingName);
                        treeView1.SelectedNode = newNode;
                        IsDataChanged = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                chFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Floor_Click(object sender, EventArgs e)
        {
            try
            {
                Building buildingCurrent = null;
                frm_Floor floorFrm = null;
                if (treeView1.SelectedNode == null) return;

                int Level = treeView1.SelectedNode.Level;
                switch (Level)
                {
                    case 0: // Select a Building Node
                        buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Text);
                        break;
                    case 1: // Select a Floor Node
                        buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Text);
                        break;
                }

                floorFrm = new frm_Floor(buildingCurrent);
                floorFrm.eventFloorChanged += new EventFloorChanged((floor) =>
                {
                    try
                    {
                        TreeNode newNode;
                        if (Level == 0)
                        {
                            newNode = treeView1.SelectedNode.Nodes.Add(floor.FloorName);
                            IsDataChanged = true;
                        }
                        else if (Level == 1)
                        {
                            newNode = treeView1.SelectedNode.Parent.Nodes.Add(floor.FloorName);
                            IsDataChanged = true;
                        }
                        else
                        {
                            return;
                        }

                        treeView1.SelectedNode = newNode;
                        treeView1.SelectedNode.Expand();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                floorFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Room_Click(object sender, EventArgs e)
        {
            try
            {
                Building buildingCurrent = null;
                Floor floorCurrent = null;
                frm_Room roomFrm = null;
                if (treeView1.SelectedNode == null) return;

                int Level = treeView1.SelectedNode.Level;
                if (Level == 1) // Select a Floor Node
                {
                    buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Text);
                    floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Text);
                }
                else
                {
                    return;
                }

                roomFrm = new frm_Room(buildingCurrent, floorCurrent);
                roomFrm.eventRoomChanged += new EventRoomChanged((room) =>
                {
                    try
                    {
                        if (Level == 1)
                        {
                            TreeNode newNode = treeView1.SelectedNode.Nodes.Add(room.RoomName);
                            IsDataChanged = true;
                            treeView1.SelectedNode.Expand();
                            treeView1.SelectedNode = newNode;
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                roomFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Device_Click(object sender, EventArgs e)
        {
            try
            {
                Building buildingCurrent = null;
                Floor floorCurrent = null;
                Room roomCurrent = null;
                frm_Device deviceFrm = null;
                if (treeView1.SelectedNode == null) return;

                int Level = treeView1.SelectedNode.Level;

                if (Level == 2)
                {
                    buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Text);
                    floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Text);
                    roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Text);
                }

                deviceFrm = new frm_Device(buildingCurrent, floorCurrent, roomCurrent);
                deviceFrm.eventDeviceChanged += new EventDeviceChanged((device) =>
                {
                    try
                    {
                        if (Level == 2) // Select a Floor Node (Node level 1)
                        {
                            TreeNode newNode = treeView1.SelectedNode.Nodes.Add(device.DeviceName);
                            IsDataChanged = true;
                            treeView1.SelectedNode.Expand();
                            treeView1.SelectedNode = newNode;
                        }
                        else
                        {
                            return;
                        }    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                deviceFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Tag_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null) return;

                Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                Device deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, treeView1.SelectedNode.Text);

                frm_Tag tgFrm = new frm_Tag(buildingCurrent, floorCurrent, roomCurrent, deviceCurrent);
                tgFrm.eventTagChanged += new EventTagChanged((tg) =>
                {
                    try
                    {
                        string[] row = { tg.TagName, string.Format("{0}", tg.Topic), string.Format("{0}", tg.QoS), tg.Retain.ToString(), tg.Description, tg.IsInput.ToString() };
                        ListViewItem item = new ListViewItem(row);
                        item.ImageIndex = 0;
                        listView1.Items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
                tgFrm.ShowDialog();
                treeView1.SelectedNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null) return;
                int Level = treeView1.SelectedNode.Level;
                string selectedNode = treeView1.SelectedNode.Text;
                DialogResult result;

                // Delete Tags
                if (listView1.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem selectedItem in listView1.SelectedItems)
                    {
                        string tagName = selectedItem.SubItems[0].Text;

                        Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                        Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                        Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                        Device deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, treeView1.SelectedNode.Text);
                        Tag tagToDelete = Tag_Manager.GetByTagName(deviceCurrent, tagName);
                        Tag_Manager.Delete(deviceCurrent, tagToDelete);
                        listView1.Items.Remove(selectedItem);
                        IsDataChanged = true;
                    }
                    return;
                }

                switch (Level)
                {
                    case 0: // Delete Building
                        result = MessageBox.Show(this, string.Format("Are you sure delete building: {0}?", selectedNode), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Building fCh = Building_Manager.GetByBuildingName(selectedNode);
                            Building_Manager.Delete(fCh);
                            treeView1.SelectedNode.Remove();
                            IsDataChanged = true;
                        }
                        break;
                    case 1: // Delete Floor
                        result = MessageBox.Show(this, string.Format("Are you sure delete floor: {0} of the building: {1}?", selectedNode, treeView1.SelectedNode.Parent.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Building fCh = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Text);
                            Floor_Manager.Delete(fCh, selectedNode);
                            treeView1.SelectedNode.Remove();
                            IsDataChanged = true;
                        }
                        break;
                    case 2: // Delete Room
                        result = MessageBox.Show(this, string.Format("Are you sure delete room: {0} of the floor: {1}, building: {2}?", selectedNode, treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Parent.Parent.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Text);
                            Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Text);
                            Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Text);
                            Room_Manager.Delete(floorCurrent, roomCurrent);
                            treeView1.SelectedNode.Remove();
                            IsDataChanged = true;
                        }
                        break;
                    case 3: // Delete Device
                        result = MessageBox.Show(this, string.Format("Are you sure delete device: {0} of the room: {1}, floor: {2}, building: {3}?", selectedNode, treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Parent.Parent.Text, treeView1.SelectedNode.Parent.Parent.Parent.Text), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                            Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                            Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                            Device deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, treeView1.SelectedNode.Text);
                            Device_Manager.Delete(roomCurrent, deviceCurrent);
                            treeView1.SelectedNode.Remove();
                            IsDataChanged = true;
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int Level = treeView1.SelectedNode.Level;
                string selectedNode = treeView1.SelectedNode.Text;
                this.Selection();
                switch (Level)
                {
                    case 0: // Selected a building
                        listView1.Items.Clear();
                        break;
                    case 1: // Selected a floor
                        listView1.Items.Clear();
                        break;
                    case 2: // Selected a room
                        listView1.Items.Clear();
                        break;
                    case 3: // Selected a device
                        Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                        Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                        Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                        Device deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, treeView1.SelectedNode.Text);
                        listView1.Items.Clear();
                        foreach (Tag tag in deviceCurrent.Tags)
                        {
                            string[] row = { tag.TagName, string.Format("{0}", tag.Topic), string.Format("{0}", tag.QoS), tag.Retain.ToString(), tag.Description, tag.IsInput.ToString() };
                            ListViewItem item = new ListViewItem(row);
                            item.ImageIndex = 0;
                            listView1.Items.Add(item);
                        }
                        break;
                    default:
                        listView1.Items.Clear();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Selection()
        {
            if (treeView1.SelectedNode == null) return;
            int Level = treeView1.SelectedNode.Level;
            switch (Level)
            {
                case 0: // Selected a building
                    mn_Building.Enabled = btn_Building.Enabled = mns_Building.Enabled = true;
                    mn_Floor.Enabled = btn_Floor.Enabled = mns_Floor.Enabled = true;
                    mn_Room.Enabled = btn_Room.Enabled = mns_Room.Enabled = false;
                    mn_Device.Enabled = btn_Device.Enabled = mns_Device.Enabled = false;
                    mn_Tag.Enabled = btn_Tag.Enabled = mns_Tag.Enabled = false;
                    break;
                case 1: // Selected a floor
                    mn_Building.Enabled = btn_Building.Enabled = mns_Building.Enabled = false;
                    mn_Floor.Enabled = btn_Floor.Enabled = mns_Floor.Enabled = false;
                    mn_Room.Enabled = btn_Room.Enabled = mns_Room.Enabled = true;
                    mn_Device.Enabled = btn_Device.Enabled = mns_Device.Enabled = true;
                    mn_Tag.Enabled = btn_Tag.Enabled = mns_Tag.Enabled = false;
                    break;
                case 2: // Selected a room
                    mn_Building.Enabled = btn_Building.Enabled = mns_Building.Enabled = false;
                    mn_Floor.Enabled = btn_Floor.Enabled = mns_Floor.Enabled = false;
                    mn_Room.Enabled = btn_Room.Enabled = mns_Room.Enabled = false;
                    mn_Device.Enabled = btn_Device.Enabled = mns_Device.Enabled = true;
                    mn_Tag.Enabled = btn_Tag.Enabled = mns_Tag.Enabled = false;
                    break;
                case 3: // Selected a device
                    mn_Building.Enabled = btn_Building.Enabled = mns_Building.Enabled = false;
                    mn_Floor.Enabled = btn_Floor.Enabled = mns_Floor.Enabled = false;
                    mn_Room.Enabled = btn_Room.Enabled = mns_Room.Enabled = false;
                    mn_Device.Enabled = btn_Device.Enabled = mns_Device.Enabled = false;
                    mn_Tag.Enabled = btn_Tag.Enabled = mns_Tag.Enabled = true;
                    break;
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.Selection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                int Level = treeView1.SelectedNode.Level;
                string selectedNode = treeView1.SelectedNode.Text;
                Building buildingCurrent = null;
                Floor floorCurrent = null;
                Room roomCurrent = null;
                Device deviceCurrent = null;

                switch (Level)
                {
                    case 0: // Select a building
                        buildingCurrent = Building_Manager.GetByBuildingName(selectedNode);
                        frm_Building buildingFrm = new frm_Building(buildingCurrent);
                        buildingFrm.eventBuildingChanged += new EventBuildingChanged((building) =>
                        {
                            treeView1.SelectedNode.Text = building.BuildingName;
                        });
                        buildingFrm.StartPosition = FormStartPosition.CenterScreen;
                        buildingFrm.ShowDialog();
                        break;
                    case 1: // Select a floor
                        buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Text);
                        floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, selectedNode);
                        frm_Floor floorFrm = new frm_Floor(buildingCurrent, floorCurrent);
                        floorFrm.eventFloorChanged += new EventFloorChanged((floor) =>
                        {
                            treeView1.SelectedNode.Text = floor.FloorName;
                        });
                        floorFrm.StartPosition = FormStartPosition.CenterScreen;
                        floorFrm.ShowDialog();
                        break;
                    case 2: // Select a room
                        buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Text);
                        floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Text);
                        roomCurrent = Room_Manager.GetByRoomName(floorCurrent, selectedNode);
                        frm_Room roomFrm = new frm_Room(buildingCurrent, floorCurrent, roomCurrent);
                        roomFrm.eventRoomChanged += new EventRoomChanged((room) =>
                        {
                            treeView1.SelectedNode.Text = room.RoomName;
                        });
                        roomFrm.StartPosition = FormStartPosition.CenterScreen;
                        roomFrm.ShowDialog();
                        break;
                    case 3: // Select a device
                        buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                        floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                        roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                        deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, selectedNode);
                        frm_Device deviceFrm = new frm_Device(buildingCurrent, floorCurrent, roomCurrent, deviceCurrent);
                        deviceFrm.eventDeviceChanged += new EventDeviceChanged((device) =>
                        {
                            treeView1.SelectedNode.Text = device.DeviceName;
                            listView1.Items.Clear();
                            foreach (Tag tag in device.Tags)
                            {
                                string[] row = { tag.TagName, string.Format("{0}", tag.Topic), string.Format("{0}", tag.QoS), tag.Retain.ToString(), tag.Description, tag.IsInput.ToString() };
                                ListViewItem item = new ListViewItem(row);
                                item.ImageIndex = 0;
                                listView1.Items.Add(item);
                            }
                        });
                        deviceFrm.StartPosition = FormStartPosition.CenterScreen;
                        deviceFrm.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                foreach (int i in listView1.SelectedIndices)
                {
                    int Level = treeView1.SelectedNode.Level;
                    if (Level != 3) return;
                    string selectedNode = treeView1.SelectedNode.Text;
                    Building buildingCurrent = Building_Manager.GetByBuildingName(treeView1.SelectedNode.Parent.Parent.Parent.Text);
                    Floor floorCurrent = Floor_Manager.GetByFloorName(buildingCurrent, treeView1.SelectedNode.Parent.Parent.Text);
                    Room roomCurrent = Room_Manager.GetByRoomName(floorCurrent, treeView1.SelectedNode.Parent.Text);
                    Device deviceCurrent = Device_Manager.GetByDeviceName(roomCurrent, selectedNode);
                    Tag tagCurrent = Tag_Manager.GetByTagName(deviceCurrent, listView1.Items[i].SubItems[0].Text);
                    frm_Tag tgFrm = new frm_Tag(buildingCurrent, floorCurrent, roomCurrent, deviceCurrent, tagCurrent);
                    tgFrm.eventTagChanged += new EventTagChanged((tag) =>
                    {
                        Tag_Manager.Update(deviceCurrent, tagCurrent);
                        listView1.Items[i].SubItems[0].Text = tag.TagName;
                        listView1.Items[i].SubItems[1].Text = string.Format("{0}", tag.Topic);
                        listView1.Items[i].SubItems[2].Text = string.Format("{0}", tag.QoS);
                        listView1.Items[i].SubItems[3].Text = tag.Retain.ToString();
                        listView1.Items[i].SubItems[4].Text = tag.Description;
                        listView1.Items[i].SubItems[5].Text = tag.IsInput.ToString();
                        IsDataChanged = true;
                    });
                    tgFrm.StartPosition = FormStartPosition.CenterScreen;
                    tgFrm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_TagManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsDataChanged == false) return;
                DialogResult rs = MessageBox.Show(this, "You sure you want to save?", Msg.MSG_QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    btn_Save_Click(sender, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
