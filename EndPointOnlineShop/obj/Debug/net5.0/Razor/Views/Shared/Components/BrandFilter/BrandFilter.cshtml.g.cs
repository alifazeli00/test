#pragma checksum "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d91955a76f0fe9899928bd76b81865aa18577c3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_BrandFilter_BrandFilter), @"mvc.1.0.view", @"/Views/Shared/Components/BrandFilter/BrandFilter.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\excore\OnlineShop\EndPointOnlineShop\Views\_ViewImports.cshtml"
using EndPointOnlineShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\excore\OnlineShop\EndPointOnlineShop\Views\_ViewImports.cshtml"
using EndPointOnlineShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
using Application.Catalogs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d91955a76f0fe9899928bd76b81865aa18577c3c", @"/Views/Shared/Components/BrandFilter/BrandFilter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc63e67c2b2f65cd07742a95bef7d729f775e046", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_BrandFilter_BrandFilter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BrandDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("widget-content"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
  
     var BRANSID = Context.Request.Query["brandId"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""widget widget-filter-options shadow-around"">
    <div class=""widget-title"">برند</div>
    <div class=""search-in-options form-element-row"">
        <div class=""form-element-with-icon"">
            <input type=""text"" class=""input-element"" placeholder=""جستجوی نام برند..."">
            <i class=""fad fa-file-search""></i>
        </div>
    </div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d91955a76f0fe9899928bd76b81865aa18577c3c5113", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 16 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
             if (BRANSID.ToList().Any(p => p == item.Id.ToString()))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <label class=\"container-checkbox\">\r\n                    ");
#nullable restore
#line 21 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
               Write(item.Brand);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <input type=\"checkbox\" checked name=\"brandId\"");
                BeginWriteAttribute("value", " value=\"", 830, "\"", 846, 1);
#nullable restore
#line 22 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
WriteAttributeValue("", 838, item.Id, 838, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"submit();\">\r\n                    <span class=\"checkmark\"></span>\r\n                </label>\r\n");
#nullable restore
#line 25 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <label class=\"container-checkbox\">\r\n                    ");
#nullable restore
#line 29 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
               Write(item.Brand);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <input type=\"checkbox\" name=\"brandId\"");
                BeginWriteAttribute("value", " value=\"", 1139, "\"", 1155, 1);
#nullable restore
#line 30 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
WriteAttributeValue("", 1147, item.Id, 1147, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"submit();\">\r\n                    <span class=\"checkmark\"></span>\r\n                </label>\r\n");
#nullable restore
#line 33 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
             

        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 37 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
         foreach (var queryString in Context.Request.Query.Where(p => p.Key != "brandId").ToList())
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1432, "\"", 1455, 1);
#nullable restore
#line 39 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
WriteAttributeValue("", 1439, queryString.Key, 1439, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1456, "\"", 1482, 1);
#nullable restore
#line 39 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
WriteAttributeValue("", 1464, queryString.Value, 1464, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 40 "D:\excore\OnlineShop\EndPointOnlineShop\Views\Shared\Components\BrandFilter\BrandFilter.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BrandDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
