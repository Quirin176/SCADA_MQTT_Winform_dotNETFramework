using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Alarm
{
    [Designer(typeof(TagManagerDesigner)), ToolboxItem(true)]
    [ToolboxBitmap(typeof(Alarms), "TagManager.png")]

    public partial class Alarms : Component
    {
        public Alarms()
        {
            InitializeComponent();
        }

        internal class TagManagerDesigner : ComponentDesigner
        {
            private DesignerActionListCollection actionLists;
            public override DesignerActionListCollection ActionLists
            {
                get
                {
                    if (actionLists == null)
                    {
                        actionLists = new DesignerActionListCollection();
                        actionLists.Add(new AlarmListItem(this));
                    }
                    return actionLists;
                }
            }
        }

        internal class AlarmListItem : DesignerActionList
        {
            private Alarms shape;
            public AlarmListItem(ComponentDesigner owner)
                : base(owner.Component)
            {
                shape = (Alarms)owner.Component;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                var items = new DesignerActionItemCollection();
                items.Add(new DesignerActionTextItem("HMI Edition", "HMI Edition"));
                items.Add(new DesignerActionMethodItem(this, "ShowTagBuilderDialog", "Alarm Manager"));
                return items;
            }

            public void ShowTagBuilderDialog()
            {
                frm_AlarmTag tagBuilderFrm = new frm_AlarmTag();
                tagBuilderFrm.ShowDialog();
            }
        }
    }
}
