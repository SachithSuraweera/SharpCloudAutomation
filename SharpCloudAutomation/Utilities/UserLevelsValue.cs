using OpenQA.Selenium.DevTools.V108.Page;

namespace SharpCloudAutomation.Utilities
{
    public class UserLevelsValue
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string StoryUrl { get; set; }

        public string StorySharePermission { get; set; }

        public RightSideToolbarPermissions RightSideToolbarPermissions { get; set; }

        public MainToolBarPermissions MainToolBarPermissions { get; set; }
    }

    public class MainToolBarPermissions
    {
        public bool MainToolbarvisibility { get; set; }

        public bool UndoVisibility { get; set; }

        public bool UndoSubMenu { get; set; }

        public bool RedoSubMenu { get; set; }

        public bool RestoreStorySubMenu { get; set; }

        public bool StoryVisibility { get; set; }

        public bool SetupSubMenu { get; set; }

        public bool ManagePresentationsSubMenu { get; set; }

        public bool ManageFormsSubMenu { get; set; }

        public bool DownloadStorySubMenu { get; set; }

        public bool DataVisibility { get; set; }

        public bool EditDataSubMenu { get; set; }

        public bool DataConnectorsSubMenu { get; set; }

        public bool ViewVisibility { get; set; }

        public bool ResetViewVisibility { get; set; }

        public bool SaveViewVisibility { get; set; }

        public bool ViewSetupSubMenu { get; set; }

        public bool FiltersSubMenu { get; set; }

        public bool AddNewSubMenu { get; set; }

        public bool SaveAsNewSubMenu { get; set; }

        public bool RelationshipsVisibility { get; set; }

        public bool ShowSubMenu { get; set; }

        public bool CreateOrEditSubMenu { get; set; }

        public bool MoreOptionsSubMenu { get; set; }

        public bool UnlockVisibility { get; set; }

        public bool SearchVisibility { get; set; }

        public bool FullScreenVisibility { get; set; }

    }

    public class RightSideToolbarPermissions
    {
        public bool RightSideToolBarVisiblility { get; set; }

        public bool SideViewEmptyVisitbility { get; set; }

        public bool SideViewEmptyExpand { get; set; }

        public bool SideViewEmptyCanEdit { get; set; }

        public bool SideViewGuideVisibility { get; set; }

        public bool SideViewGuideExpand { get; set; }

        public bool SideViewGuideCanEdit { get; set; }

        public bool SideViewFormVisibility { get; set; }

        public bool SideViewFormExpand { get; set; }
        public bool SideViewFormCanUse { get; set;}

        public bool CommentsVisibility { get; set; }

        public bool CommentsCanEditComment { get; set; }

        public bool EditVisibility { get; set; }

        public bool EditCanEdit { get; set; }

        public bool WidgetsVisibility { get; set; }

        public bool WidgetsCanEdit { get; set; }

        public bool FormsVisibility { get; set; }

        public bool FormsCanUse { get; set; }

        public bool ActivityCanUse { get; set; }

    }
}
