package com.example.angel.nideas;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebView;


public class HomeActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

//        getSupportActionBar().setDisplayUseLogoEnabled(true);
//        getSupportActionBar().setDisplayShowHomeEnabled(true);
//        getSupportActionBar().setIcon(R.drawable.icon);

        WebView webView = (WebView)findViewById(R.id.webView);
        webView.getSettings().setDomStorageEnabled(true);
        webView.getSettings().setJavaScriptEnabled(true);
        String summary =
                "<!DOCTYPE html>" +
                "<html lang='en'>" +
                    "<head>" +
                        "<meta name='viewport' content='width=device-width, initial-scale=1'>" +
                    "</head>"+
                    "<body>"+
                        "<link href='file:///android_asset/bootstrap/css/bootstrap.min.css' rel='stylesheet' />\n" +
                        "<link href='file:///android_asset/bootstrap/css/bootstrap-theme.min.css' rel='stylesheet' />"+
                        "<script src='file:///android_asset/jquery/jquery.js'></script>"+
                        "<script src='file:///android_asset/bootstrap/js/bootstrap.min.js'></script>"+
                        "<div class='container'>" +
                            "<div class='row'>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>\n" +
                                    "<header style='border-bottom: 1px solid black'>Title</header>" +
                                    "<section>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. </section>" +
                                    "<footer style='border-top: 1px solid black; padding: 5px'>" +
                                        "<span class='glyphicon glyphicon-heart'></span>" +
                                        "<span class='glyphicon glyphicon-star'></span>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "<span class='glyphicon glyphicon-eye-open'></span>" +
                                    "</footer>" +
                                "</article>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>\n" +
                                    "<header style='border-bottom: 1px solid black'>Title</header>" +
                                    "<section>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. </section>" +
                                    "<footer style='border-top: 1px solid black; padding: 5px'>" +
                                        "<span class='glyphicon glyphicon-heart'></span>" +
                                        "<span class='glyphicon glyphicon-star'></span>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "<span class='glyphicon glyphicon-eye-open'></span>" +
                                    "</footer>" +
                                "</article>" +
                                "<article class='col-xs-5 col-xs-offset-1' style='background-color:#CCC; margin:10px; border: 1px solid black'>\n" +
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
