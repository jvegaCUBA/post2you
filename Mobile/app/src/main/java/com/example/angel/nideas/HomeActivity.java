package com.example.angel.nideas;

import android.os.Build;
import android.support.annotation.NonNull;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.ArrayMap;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebResourceRequest;
import android.webkit.WebResourceResponse;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.StringBufferInputStream;
import java.nio.charset.StandardCharsets;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;


public class HomeActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

//        getSupportActionBar().setDisplayUseLogoEnabled(true);
//        getSupportActionBar().setDisplayShowHomeEnabled(true);
//        getSupportActionBar().setIcon(R.drawable.icon);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT) {
            WebView.setWebContentsDebuggingEnabled(true);
        }

        final WebView webView = (WebView)findViewById(R.id.webView);
        webView.getSettings().setDomStorageEnabled(true);
        webView.getSettings().setJavaScriptEnabled(true);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN)
            webView.getSettings().setAllowUniversalAccessFromFileURLs(true);
        //webView.getSettings().setAllowUniversalAccessFromFileURLs(true);
        String summary =
                "<!DOCTYPE html>" +
                "<html lang='en'>" +
                    "<head>" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                    "</head>"+
                    "<body>"+
                        "<link href='file:///android_asset/bootstrap/css/bootstrap.min.css' rel='stylesheet' />" +
                        "<link href='file:///android_asset/bootstrap/css/bootstrap-theme.min.css' rel='stylesheet' />"+
                        "<script src='file:///android_asset/jquery/jquery.js'></script>"+
                        "<script src='file:///android_asset/bootstrap/js/bootstrap.min.js'></script>" +
                        "<script>" +
                            "function xxx(x){console.info(x)}" +
                            "console.info('lololo');" +
                            "$.ajax({" +
                            "  crossDomain: true," +
                            "  url: 'http://nideas.com/test'," +
                            "  context: document.body" +
                            "}).done(function(data) {" +
                            "  $( this ).addClass( 'done' );" +
                            "  console.info(data);" +
                            "});" +
                        "</script>"+
                        "<div class='container'>" +
                            "<div class='row'>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>" +
                                    "<header style='border-bottom: 1px solid black'>Title</header>" +
                                    "<section>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. </section>" +
                                    "<footer style='border-top: 1px solid black; padding: 5px'>" +
                                        "<span class='glyphicon glyphicon-heart'></span>" +
                                        "<span class='glyphicon glyphicon-star'></span>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "<span class='glyphicon glyphicon-eye-open'></span>" +
                                    "</footer>" +
                                "</article>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>" +
                                    "<header style='border-bottom: 1px solid black'>Title</header>" +
                                    "<section>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. </section>" +
                                    "<footer style='border-top: 1px solid black; padding: 5px'>" +
                                        "<span class='glyphicon glyphicon-heart'></span>" +
                                        "<span class='glyphicon glyphicon-star'></span>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "<span class='glyphicon glyphicon-eye-open'></span>" +
                                    "</footer>" +
                                "</article>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>" +
                                    "<header style='border-bottom: 1px solid black'>Title</header>" +
                                    "<section>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. </section>" +
                                    "<footer style='border-top: 1px solid black; padding: 5px'>" +
                                        "<span class='glyphicon glyphicon-heart'></span>" +
                                        "<span class='glyphicon glyphicon-star'></span>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "<span class='glyphicon glyphicon-eye-open'></span>" +
                                    "</footer>" +
                                "</article>" +

                            "</div>"+
                        "</div>"+
                    "</body>" +
                "</html>";
        webView.setWebViewClient(new WebViewClient(){
            @Override
            public WebResourceResponse shouldInterceptRequest(WebView view, String url) {

                String action = url.replace("http://nideas.com/", "");
                switch (action)
                {
                    case "test":

                        String result = "zjfajshdfsdfbjasdbf";
                        InputStream stream = new ByteArrayInputStream(result.getBytes());
                        return new WebResourceResponse("text/html", "utf-8", stream);

                }

                return super.shouldInterceptRequest(view, url);
            }
        });
        webView.loadDataWithBaseURL("file:///android_asset/",summary, "text/html", null, null);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_home, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
