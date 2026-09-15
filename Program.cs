using System;
using Raylib_cs;

namespace Space_lasergame
{
    class Space
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1920, 1100, "Space Game");
            Raylib.SetTargetFPS(60);
            Texture2D space_ship = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\space laser game\\space_ship.png");
            Texture2D meteroite = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\space laser game\\meteorite.png");
            Texture2D Background = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\space laser game\\space_background.png");
            Texture2D laser = Raylib.LoadTexture("C:\\Users\\ryan\\OneDrive\\Documents\\C#\\space laser game\\laser.png");


            int player_height = 213;
            int player_width = 322;
            int player_x = 800;
            int player_y = 800;
            int player_speed = 35;

            int laser_width = 10;
            int laser_height = 101;
            int laser_speed = 20;
            int laser_x = player_x;
            int laser_y = player_y;
            bool laser_active = false;


            int enemy_width = 146;
            int enemy_height = 144;
            int enemy_x = Raylib.GetRandomValue(0, 1920 - enemy_width);
            int enemy_y = -enemy_height;
            int enemy_speed = 10;

            Color Green = new Color(0,255,0,255);

            int score = 0;
            bool game_over = false;


            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                if(!game_over)
                {
                    if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                    {
                        if (player_y > 0)
                        {
                            player_y -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                    {
                        if (player_x > 0)
                        {
                            player_x -= player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                    {
                        if (player_y < 1100 - player_height)
                        {
                            player_y += player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                    {
                        if (player_x < 1920 - player_width)
                        {
                            player_x += player_speed;
                        }
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.F))
                    {
                        if(!laser_active)
                        {
                            laser_x = player_x + (player_width / 2) - (laser_width / 2);
                            laser_y = player_y;
                            laser_active = true;
                        }
                    }
                    if (laser_active)
                    {
                        laser_y -= laser_speed;
                        Raylib.DrawTexture(laser,laser_x,laser_y,Color.White);
                        Raylib.DrawTexture(meteroite, enemy_x, enemy_y, Color.White);

                        if (laser)
                        {
                            score += 1;
                            laser_active = false;
                            enemy_x = Raylib.GetRandomValue(0, 1920 - enemy_width);
                            enemy_y = -enemy_height;
                        }
                        if (laser_y < 0)
                        {
                            laser_active = false;
                        }
                    }
                    enemy_y += enemy_speed;
                    if(enemy_y > 1200)
                    {
                        enemy_x = Raylib.GetRandomValue(0, 1920 - enemy_width);
                        enemy_y = -enemy_height;
                    }
                    Raylib.DrawTexture(space_ship, player_x, player_y, Color.White);
                    Raylib.DrawTexture(meteroite, enemy_x, enemy_y, Color.White);
                    if (space_ship)
                    {
                        game_over = true;
                    }
                }
                Raylib.DrawTexture(Background, 0, 0, Color.White);
                Raylib.DrawTexture(space_ship, player_x, player_y, Color.White);
                Raylib.DrawTexture(meteroite, enemy_x, enemy_y, Color.White);

                if(laser_active)
                {
                    Raylib.DrawTexture(laser, laser_x, laser_y, Color.White);
                }
                if (!game_over)
                {
                    Raylib.DrawText($"Score: {score}", 325, 200, 30, Color.Green);
                }
                else
                {
                    int over_surf = Raylib.MeasureText($"Final Score: {score}",30);
                    int text_x = (1920 / 2) - (over_surf / 2);
                    int text_y = (1100 / 2) - (30 / 2);
                    Raylib.DrawText($"Final Score: {score}", text_x,text_y,30,Color.White);
                }
            }
            Raylib.EndDrawing();
        }
    }
}