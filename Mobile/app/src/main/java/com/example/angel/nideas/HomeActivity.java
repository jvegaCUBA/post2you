package com.example.angel.nideas;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Intent;
import android.os.Build;
import android.os.Handler;
import android.os.Looper;
import android.os.Message;
import android.support.annotation.NonNull;
import android.support.v4.app.NotificationCompat;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.ArrayMap;
import android.view.Menu;
import android.view.MenuItem;
import android.webkit.WebResourceRequest;
import android.webkit.WebResourceResponse;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.StringBufferInputStream;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;
import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;


public class HomeActivity extends ActionBarActivity {

    private Socket socket;
    private static final int SERVERPORT = 3333;
    private static final String SERVER_IP = "172.10.1.1";
    private Handler mHandler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        //esto es para iniciar el socket
        mHandler = new Handler(Looper.getMainLooper()) {
            /*
             * handleMessage() defines the operations to perform when
             * the Handler receives a new Message to process.
             */
            @Override
            public void handleMessage(Message inputMessage) {
                // Gets the image task from the incoming Message object.
                //PhotoTask photoTask = (PhotoTask) inputMessage.obj;
            }
        };
        new Thread(new ClientThread()).start();




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

        webView.loadUrl("file:///android_asset/home.html");
        //webView.loadDataWithBaseURL("file:///android_asset/",summary, "text/html", null, null);
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

    class ClientThread implements Runnable {
        @Override
        public void run() {
            try {
                InetAddress serverAddr = InetAddress.getByName(SERVER_IP);
                socket = new Socket(serverAddr, SERVERPORT);
                while (true)
                {
                    BufferedReader r = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    final StringBuilder total = new StringBuilder();
                    String line;
                    while ((line = r.readLine()) != null) {
                        total.append(line).append('\n');
                    }

                    if(total.length() != 0)
                    {
                        mHandler.post(new Runnable() {
                            @Override
                            public void run() {
                                //Toast.makeText(getBaseContext(), total.toString(), Toast.LENGTH_SHORT).show();
                                NotificationCompat.Builder mBuilder =
                                        new NotificationCompat.Builder(getBaseContext())
                                                .setSmallIcon(R.drawable.icon)
                                                .setContentTitle(total.toString())
                                                .setContentText(total.toString());

                                Intent resultIntent = new Intent(getBaseContext(), MainActivity.class);
                                PendingIntent resultPendingIntent =
                                        PendingIntent.getActivity(
                                                getBaseContext(),
                                                0,
                                                resultIntent,
                                                PendingIntent.FLAG_UPDATE_CURRENT
                                        );

                                mBuilder.setContentIntent(resultPendingIntent);

                                // Sets an ID for the notification
                                int mNotificationId = 001;
                                // Gets an instance of the NotificationManager service
                                NotificationManager mNotifyMgr =
                                        (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
                                // Builds the notification and issues it.
                                mNotifyMgr.notify(mNotificationId, mBuilder.build());
                            }
                        });
                    }

                }
            } catch (IOException e1) {
                e1.printStackTrace();
            }
        }
    }
}
