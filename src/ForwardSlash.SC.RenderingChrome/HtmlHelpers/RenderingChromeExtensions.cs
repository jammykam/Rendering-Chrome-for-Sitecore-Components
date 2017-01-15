using System.Web;
using Sitecore.Configuration;
using Sitecore.Mvc.Helpers;

namespace ForwardSlash.SC.RenderingChrome.HtmlHelpers
{
    public static class RenderingChromeExtensions
    {
        private const string DisplayExtendedInfo = "RenderingChrome.DisplayExtededInfo";

        public static IHtmlString ContainerChrome(this SitecoreHelper helper)
        {
            return helper.ContainerChrome(null);
        }

        public static IHtmlString ContainerChrome(this SitecoreHelper helper, string title)
        {
            return helper.GetChromeAttribute(title, "container");
        }

        public static IHtmlString WidgetChrome(this SitecoreHelper helper)
        {
            return helper.WidgetChrome(null);
        }

        public static IHtmlString WidgetChrome(this SitecoreHelper helper, string title)
        {
            return helper.GetChromeAttribute(title, "widget");
        }

        private static IHtmlString GetChromeAttribute(this SitecoreHelper helper, string title, string attribute)
        {
            /* Earlier version of Sitecore? Use: Sitecore.Context.PageMode.IsPageEditor */
            if (!Sitecore.Context.PageMode.IsExperienceEditor)
                return null;

            if (string.IsNullOrWhiteSpace(title))
                title = helper.CurrentRendering.RenderingItem.DisplayName;

            if (Settings.GetBoolSetting(DisplayExtendedInfo, false))
                title += $" ({helper.CurrentRendering.Renderer})";

            string htmlString = $"data-{attribute}-title=\"{title}\"" + WrapperTitle(title);
            return new HtmlString(htmlString);
        }

        private static string WrapperTitle(string title)
        {
            return Settings.GetBoolSetting(DisplayExtendedInfo, false) ? $" title=\"{title}\"" : null;
        }
    }
}
