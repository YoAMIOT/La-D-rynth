using Godot;
using System;
using System.Threading.Tasks;

public class DataManager : Node {

    public Godot.Collections.Dictionary playerDatas = new Godot.Collections.Dictionary();
    private string playerDatasFile = "res://data/playerDatas.json";

    public override void _Ready() {
        loadPlayerDatas();
    }
    
    public void loadPlayerDatas(){
        File file = new File();
        if (!file.FileExists(playerDatasFile)) {
            savePlayerDatas();
            return;
        }
        file.Open(playerDatasFile, File.ModeFlags.Read);
        if (file.GetAsText() != "") {
            playerDatas = (Godot.Collections.Dictionary)JSON.Parse(file.GetAsText()).Result;
            file.Close();
        }
    }

    public void savePlayerDatas(){
        File file = new File();
        file.Open(playerDatasFile, File.ModeFlags.Write);
        file.StoreLine(JSON.Print(playerDatas));
        file.Close();
    }
}
