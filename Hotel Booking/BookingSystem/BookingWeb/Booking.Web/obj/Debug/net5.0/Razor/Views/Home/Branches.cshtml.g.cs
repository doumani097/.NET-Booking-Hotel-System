#pragma checksum "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a9dc6a04ea46c74a3642b5b8585d923be7e1101"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Branches), @"mvc.1.0.view", @"/Views/Home/Branches.cshtml")]
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
#line 1 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\_ViewImports.cshtml"
using Booking.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\_ViewImports.cshtml"
using BookingWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a9dc6a04ea46c74a3642b5b8585d923be7e1101", @"/Views/Home/Branches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"938a264c6a9114d5b30148e71587d80d071c8d65", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Branches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<BookingWeb.Models.Branch>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Rooms", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
  
    ViewData["Title"] = "Sea Horizon";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"branches my-5\">\r\n    <div class=\"container\">\r\n        <div class=\"row mt-5\">\r\n");
#nullable restore
#line 9 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
             if(Model.Count() > 0)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                 foreach (var branch in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-4\">\r\n                        <div class=\"card mt-3\">\r\n");
#nullable restore
#line 15 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                              
                                var base64 = Convert.ToBase64String(@branch.Image);
                                var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 666, "\"", 679, 1);
#nullable restore
#line 19 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
WriteAttributeValue("", 672, imgsrc, 672, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n                            <div class=\"card-body\">\r\n                                <h5 class=\"card-title\">");
#nullable restore
#line 21 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                                                  Write(branch.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 22 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                                                Write(branch.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 23 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                                                Write(branch.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <p class=\"card-text\">");
#nullable restore
#line 24 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                                                Write(branch.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a9dc6a04ea46c74a3642b5b8585d923be7e11017631", async() => {
                WriteLiteral("Available Rooms");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-branchId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                                                              WriteLiteral(branch.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-branchId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["branchId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\n");
#nullable restore
#line 29 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
                 
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>There are no branches available now in this location...</h2>\r\n");
#nullable restore
#line 34 "D:\Development\Projects\Asp.net core\Hotel Booking System\Hotel Booking\BookingSystem\BookingWeb\Booking.Web\Views\Home\Branches.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<BookingWeb.Models.Branch>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
