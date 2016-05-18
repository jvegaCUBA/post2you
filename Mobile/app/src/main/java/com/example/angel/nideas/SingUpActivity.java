package com.example.angel.nideas;

import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;


public class SingUpActivity extends ActionBarActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sing_up);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_sing_up, menu);
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

    public void onSingUpClick(View view)
    {

        TextView user = (TextView)findViewById(R.id.editText);
        TextView email = (TextView)findViewById(R.id.editText2);
        TextView password = (TextView)findViewById(R.id.editText3);

        //comprobar contra el servidor si las credenciales son validas
        //...


        SQLiteDatabase sqLiteDatabase = openOrCreateDatabase("android_asset/database/database.sqlite",MODE_PRIVATE,null);
        sqLiteDatabase.execSQL("INSERT INTO user(user, email) VALUES('" + user + "','" + email + "');");
        sqLiteDatabase.close();

    }
}
