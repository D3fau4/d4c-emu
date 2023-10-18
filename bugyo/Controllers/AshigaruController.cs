using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bugyo.Controllers;

[ApiController]
[Route("")]
public class AshigaruController : ControllerBase
{
    [HttpGet("ashigaru-assets/environment.json")]
    public ActionResult<string> getEnvironmentJSON()
    {
        return Ok("{\n  \"name\": \"lp1\",\n  \"nasHostname\": \"accounts.nintendo.com\",\n  \"nasParam\": {\n    \"client_id\": \"e56201e414c97a10\",\n    \"state\": \"STATESTATE\"\n  }\n}\n");
    }
    
    [HttpGet("ashigaru/")]
    public ContentResult getAshigaru()
    {
        return Content("<!DOCTYPE html><html><head><script type=\"text/javascript\">!function(r){var o=\"undefined\"!=typeof nx,i={isNX:o,showError:function(r){if(o){var i=window.nx.system.makeErrorCode(2811,r);window.nx.system.showError(i)}else alert(\"2811-\"+r)},shutdown:function(){o?window.location.href=\"eshop://\":alert(\"shutdown\")},ashigaruErrorShutDown:function(){this.showError(\"5001\"),this.shutdown()},isAshigaruFile:function(r){return/^\\/ashigaru-assets\\/|^https:\\/\\/.*\\.eshop\\.nintendo\\.net\\//.test(r)},isScriptLoadError:function(r){return\"script\"===r.localName&&this.isAshigaruFile(r.src)},isCssLoadError:function(r){return\"link\"===r.localName&&this.isAshigaruFile(r.href)}};r.ShopN=i,r.addEventListener(\"error\",(function(r){var o=r.target,n=i.isCssLoadError(o),s=i.isScriptLoadError(o);(n||s)&&(navigator.onLine?i.ashigaruErrorShutDown():window.location.reload())}),!0)}(window)</script><script>window.dataLayer=window.dataLayer||[],window.optimizeParams={}</script><!-- Google Tag Manager --><script>!function(e,t,a,n,g){e[n]=e[n]||[],e[n].push({\"gtm.start\":(new Date).getTime(),event:\"gtm.js\"});var m=t.getElementsByTagName(a)[0],r=t.createElement(a);r.async=!0,r.src=\"https://www.googletagmanager.com/gtm.js?id=GTM-MMHC6TP\",m.parentNode.insertBefore(r,m)}(window,document,\"script\",\"dataLayer\")</script><!-- End Google Tag Manager --><!-- Treasure Data --><script type=\"text/javascript\">!function(t,e){if(void 0===e[t]){e[t]=function(){e[t].clients.push(this),this._init=[Array.prototype.slice.call(arguments)]},e[t].clients=[];for(var r=function(t){return function(){return this[\"_\"+t]=this[\"_\"+t]||[],this[\"_\"+t].push(Array.prototype.slice.call(arguments)),this}},c=[\"addRecord\",\"set\",\"trackEvent\",\"trackPageview\",\"trackClicks\",\"ready\",\"fetchGlobalID\",\"fetchUserSegments\"],s=0;s<c.length;s++){var a=c[s];e[t].prototype[a]=r(a)}var i=document.createElement(\"script\");i.type=\"text/javascript\",i.async=!0,i.src=(\"https:\"===document.location.protocol?\"https:\":\"http:\")+\"//cdn.treasuredata.com/sdk/1.9.2/td.min.js\";var n=document.getElementsByTagName(\"script\")[0];n.parentNode.insertBefore(i,n)}}(\"Treasure\",this)</script><!-- End Treasure Data --><title>ShopN</title><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width,initial-scale=1,user-scalable=no\"><script type=\"text/javascript\">window.performance.mark=window.performance.mark||window.performance.webkitMark,window.__temp_performance=window.performance,performance.mark(\"App:CssLoad:Start\")</script><link rel=\"shortcut icon\" href=\"/ashigaru-assets/favicon.ico\"><link href=\"/ashigaru-assets/styles.8cd72f4a.css\" rel=\"stylesheet\"></head><body><div id=\"app\"></div><script type=\"text/javascript\">performance.mark(\"App:JSLoad:Start\")</script><script src=\"/ashigaru-assets/styles.f16232bfa57b49ea354d.js\"></script><script src=\"/ashigaru-assets/vendors~app~vendor.3f6b58eb2e07ec20fb34.js\"></script><script src=\"/ashigaru-assets/app.2ffd84673f22b2afbf58.js\"></script><script src=\"/ashigaru-assets/vendors~vendor.631f4400c52bce665c51.js\"></script><script src=\"/ashigaru-assets/vendor.1dbe0eb6101a2045dcd8.js\"></script></body></html>", "text/html");
    }
}