#pragma checksum "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\RazorSampleWithVM\CustomTagHelper.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13f581cb7610524964fb951596e207e0922db4b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RazorSampleWithVM_CustomTagHelper), @"mvc.1.0.view", @"/Views/RazorSampleWithVM/CustomTagHelper.cshtml")]
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
#line 1 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\_ViewImports.cshtml"
using ASPNETCORE_MVCSamples;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\_ViewImports.cshtml"
using ASPNETCORE_MVCSamples.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\RazorSampleWithVM\CustomTagHelper.cshtml"
using ASPNETCORE_MVCSamples.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f581cb7610524964fb951596e207e0922db4b9", @"/Views/RazorSampleWithVM/CustomTagHelper.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a12e62a0385164f1129db5296446ac4f320b128", @"/Views/_ViewImports.cshtml")]
    public class Views_RazorSampleWithVM_CustomTagHelper : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::ASPNETCORE_MVCSamples.TagHelpers.WebsiteInformationTagHelper __ASPNETCORE_MVCSamples_TagHelpers_WebsiteInformationTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\RazorSampleWithVM\CustomTagHelper.cshtml"
  
    ViewData["Title"] = "CustomTagHelper";
    Layout = "~/Views/Shared/_Layout.cshtml";

    WebsiteContext webContext = new WebsiteContext
    {
        Version = new Version(1, 3),
        CopyrightYear = 1638,
        Approved = true,
        TagsToShow = 131
    };


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>CustomTagHelper</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("website-information", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "13f581cb7610524964fb951596e207e0922db4b94123", async() => {
            }
            );
            __ASPNETCORE_MVCSamples_TagHelpers_WebsiteInformationTagHelper = CreateTagHelper<global::ASPNETCORE_MVCSamples.TagHelpers.WebsiteInformationTagHelper>();
            __tagHelperExecutionContext.Add(__ASPNETCORE_MVCSamples_TagHelpers_WebsiteInformationTagHelper);
#nullable restore
#line 20 "C:\Aktueller Kurs\Powerwocher_ASPNETMVC_WEBAPI_14_06_2021Kurs\ASPNETCORE_MVCSamples\Views\RazorSampleWithVM\CustomTagHelper.cshtml"
__ASPNETCORE_MVCSamples_TagHelpers_WebsiteInformationTagHelper.Info = webContext;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("info", __ASPNETCORE_MVCSamples_TagHelpers_WebsiteInformationTagHelper.Info, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591