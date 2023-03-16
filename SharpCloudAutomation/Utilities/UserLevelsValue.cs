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

        public RightSideToolbarPermissions SideViewEmptyVisitbility { get; set; }

        public RightSideToolbarPermissions SideViewEmptyExpand { get; set; }

        public RightSideToolbarPermissions SideViewEmptyCanEdit { get; set; }

        public RightSideToolbarPermissions SideViewGuideVisibility { get; set; }

        public RightSideToolbarPermissions SideViewGuideExpand { get; set; }

        public RightSideToolbarPermissions SideViewGuideCanEdit { get; set; }

        public RightSideToolbarPermissions SideViewFormVisibility { get; set; }

        public RightSideToolbarPermissions SideViewFormExpand { get; set; }

        public RightSideToolbarPermissions SideViewFormCanUse { get; set; }

        public RightSideToolbarPermissions CommentsVisibility { get; set; }

        public RightSideToolbarPermissions CommentsCanEditComment { get; set; }

        public RightSideToolbarPermissions EditVisibility { get; set; }

        public RightSideToolbarPermissions EditCanEdit { get; set; }

        public RightSideToolbarPermissions WidgetsVisibility { get; set; }

        public RightSideToolbarPermissions WidgetsCanEdit { get; set; }

        public RightSideToolbarPermissions FormsVisibility { get; set; }

        public RightSideToolbarPermissions FormsCanUse { get; set; }

        public RightSideToolbarPermissions ActivityCanUse { get; set; }


    }

    public class RightSideToolbarPermissions
    {
        public bool RightSideToolBarVisiblility { get; set; }

        public bool SideViewEmptyVisibility { get; set; }

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
