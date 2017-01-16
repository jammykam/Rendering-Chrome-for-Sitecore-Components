# Highlight Sitecore Components with Rendering Chrome

Default styling based on Zurb Foundation 5 framework, with some testing carried out on Bootstrap. You may need to tweak them to work correctly for other frameworks.

Tested with Sitecore 8.0 and 8.1+. 

## Usage

Add a reference to the Helper namespace in the `web.config` file in your Views folder (otherwise you'll have to add a using statement into your views).

```xml
<pages pageBaseType="System.Web.Mvc.WebViewPage">
  <namespaces>
    ...
    <add namespace="ForwardSlash.SC.RenderingChrome.HtmlHelpers" />
  </namespaces>
</pages>
```

Call the helper on the components you want to Rendering Chrome to be added to, for example:

```html
<div class="whatever-as-normal" @Html.Sitecore.ContainerChrome()>
   ... 
</div>
```

Two helpers are provided:

* `@Html.Sitecore().ContainerChrome()` - Adds a grey border and uses component name as specified in Sitecore Item. Suggested usage around Placeholders.
* `@Html.Sitecore().WidgetChrome()` - Adds a coloured border. Suggested usage around renderings/components.

You can call the overloaded methods and pass in the text to display instead if you need:

* `@Html.Sitecore().ContainerChrome("This is the custom container title")`
* `@Html.Sitecore().WidgetChrome("This is the custom widget title")`

Note that there is slight different in the JavaScript between Sitecore 8.0 and 8.1 and therefore there is a different file based on your version. You need to remove the `.sc80` from the file. If you're compiling the code yourself, also note that `PageMode` was changed to `IsExperienceEditor` in Sitecore 8.1 so you may get compile error for earlier versions so you'll need to change this line.

## Screenshots

![Regular Experience Editor Mode](screenshots/highlight-regular-ee-mode.png?raw=true "Regular Experience Editor Mode")

![Highlight View Renderings](screenshots/highlight-view-rendering-chrome.png?raw=true "Highlight View Renderings")

![Highlight Controller Renderings](screenshots/highlight-controller-rendering-chrome.png?raw=true "Highlight Controller Renderings")
