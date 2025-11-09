using Driver_Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI_Edition.TagManager
{
    [Designer(typeof(TagManagerDesigner)), ToolboxItem(true)]
    [ToolboxBitmap(typeof(TagManager), "TagManager.png")]

    public partial class TagManager : Component
    {
        public TagManager()
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
                        actionLists.Add(new TagManagerListItem(this));
                    }
                    return actionLists;
                }
            }
        }

        internal class TagManagerListItem : DesignerActionList
        {
            private TagManager shape;
            public TagManagerListItem(ComponentDesigner owner)
                : base(owner.Component)
            {
                shape = (TagManager)owner.Component;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                var items = new DesignerActionItemCollection();
                items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
                items.Add(new DesignerActionMethodItem(this, "ShowTagBuilderDialog", "Tag Manager"));
                return items;
            }

            public void ShowTagBuilderDialog()
            {
                frm_TagManagement tagBuilderFrm = new frm_TagManagement();
                tagBuilderFrm.ShowDialog();
            }
        }
    }
}
