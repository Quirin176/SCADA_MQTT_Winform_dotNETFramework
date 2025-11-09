using Driver_Tool.Dialog;
using Driver_Tool.Manager;
using MQTT_Protocol.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Driver_Tool
{
    public delegate void EventTagSelected(string tagName);

    public partial class frm_TagList : Form
    {
        private string DUONG_DAN = string.Empty;
        public EventTagSelected OnTagSelected_Clicked = null;
        public frm_TagList(string tagNameSelected = null)
        {
            InitializeComponent();
            //lblValueInfo.Text = string.Format("{0}", tagNameSelected);
        }

        private void frm_TagList_Load(object sender, EventArgs e)
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int Level = treeView1.SelectedNode.Level;
                string selectedNode = treeView1.SelectedNode.Text;
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in listView1.SelectedIndices)
                {
                    //lblValueInfo.Text = string.Format("{0}.{1}.{2}.{3}", treeView1.SelectedNode.Parent.Parent.Text, treeView1.SelectedNode.Parent.Text, treeViewSI.SelectedNode.Text, listViewSI.SelectedItems[0].Text.ToString());
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
                    string tagName = string.Format("{0}/{1}/{2}/{3}/{4}", treeView1.SelectedNode.Parent.Parent.Parent.Text, treeView1.SelectedNode.Parent.Parent.Text, treeView1.SelectedNode.Parent.Text, treeView1.SelectedNode.Text, listView1.SelectedItems[0].Text.ToString());
                    //lblValueInfo.Text = tagName;
                    if (OnTagSelected_Clicked != null) OnTagSelected_Clicked(tagName);
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_TagList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //switch (e.CloseReason)
                //{
                //    case CloseReason.UserClosing:
                //        DialogResult rs = MessageBox.Show(this, "You sure you want to close the application?", MSG.MSG_QUESTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (rs == System.Windows.Forms.DialogResult.Yes)
                //        {
                //            this.Opacity = 0;
                //            try
                //            {
                //                this.Close();
                //                //Application.ExitThread();
                //            }
                //            catch (Exception ex)
                //            {
                //                throw ex;
                //            }
                //        }
                //        else
                //        {
                //            e.Cancel = true;
                //        }
                //        break;
                //    case CloseReason.ApplicationExitCall:
                //        try
                //        {
                //        }
                //        catch (Exception) { }
                //        break;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Msg.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
