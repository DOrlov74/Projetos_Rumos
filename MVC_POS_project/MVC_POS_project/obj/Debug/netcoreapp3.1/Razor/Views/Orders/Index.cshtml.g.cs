#pragma checksum "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75f136843fb2a82c95c6237f2d21ef3c894cdd1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
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
#line 1 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\_ViewImports.cshtml"
using MVC_POS_project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\_ViewImports.cshtml"
using MVC_POS_project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75f136843fb2a82c95c6237f2d21ef3c894cdd1f", @"/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a86b8414555ad5ff44c64ecd4f95d1ee59d935", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MVC_POS_project.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
  
    ViewData["Title"] = "Orders";
    var currentUser = await UserManager.GetUserAsync(User);
    ViewBag.CurrentUser = currentUser;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Orders</h2>\r\n");
#nullable restore
#line 12 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
 if (ViewBag.CurrentUser != null && await UserManager.IsInRoleAsync(ViewBag.CurrentUser, "admin"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75f136843fb2a82c95c6237f2d21ef3c894cdd1f5137", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 17 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n");
#nullable restore
#line 75 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""d-flex justify-content-between"">
                <div class=""d-flex justify-content-start"">
                    <div class=""d-flex flex-column order-details"">
                        <div>Order code:</div>
                        <div>Created:</div>
                        <div>Total price:</div>
                    </div>
                    <div class=""d-flex flex-column"">
                        <div>");
#nullable restore
#line 85 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                        Write(item.DocNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div>");
#nullable restore
#line 86 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                        Write(item.CteatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div>");
#nullable restore
#line 87 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                        Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"d-flex flex-column order-details\">\r\n");
#nullable restore
#line 91 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                     if (item.Paid)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"order__payed\">Payed</div>");
#nullable restore
#line 93 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                             }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"order__active\">Active</div>");
#nullable restore
#line 96 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 99 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
             foreach (var line in item.SaleLines)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"d-flex justify-content-between line-details\">\r\n                    <div class=\"line-details__title\">");
#nullable restore
#line 102 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                Write(line.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"d-flex justify-content-end align-items-center line-details__price\">\r\n                        <div class=\"d-flex flex-column\"><div>Quantity:</div><div>");
#nullable restore
#line 104 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                                            Write(line.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></div>\r\n                        <div class=\"d-flex flex-column\"><div>Unit price:</div><div>");
#nullable restore
#line 105 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                                              Write(line.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></div>\r\n                        <div class=\"d-flex flex-column\"><div>Line price:</div><div>");
#nullable restore
#line 106 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                                                              Write(line.LinePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div></div>\r\n                        <div class=\"line-details__delete-btn\"></div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 110 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
             if (!item.Paid)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75f136843fb2a82c95c6237f2d21ef3c894cdd1f11652", async() => {
                WriteLiteral("Add product");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75f136843fb2a82c95c6237f2d21ef3c894cdd1f13035", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 115 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "g:\Dan\Rumos\Repos\MVC_POS_project\MVC_POS_project\Views\Orders\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Customer> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<Customer> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MVC_POS_project.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591