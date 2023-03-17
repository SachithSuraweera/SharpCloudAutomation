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
