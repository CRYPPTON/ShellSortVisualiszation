using Raylib_cs;
using System.Numerics;

using System;
using System.Collections.Generic;

namespace RayLibCube
{
    class Program
    {
        const int screenWidth = 500;
        const int screenHeight = 400;

        static Rectangle food;
        static Vector2 dir;  //0,0 stoped 1,0 left 0,1 right
        static Rectangle[] snake = new Rectangle[10];
        static float snakeSpeed = 20.0f;
        static int snakeSize = 0;

        static void Main(string[] args)
        {

            int framesCounter = 0;
            food = new Rectangle(200,240, 20, 20);

            snake[0] = new Rectangle(0, 0, 20, 20);
            dir = new Vector2(0, 0);

            Random randFoodPosition = new Random();


            Raylib.InitWindow(screenWidth, screenHeight, "Snake game");
            Raylib.SetTargetFPS(60);



            float deltaTime = Raylib.GetFrameTime();


            while (!Raylib.WindowShouldClose())
            {

                
                    for (int i = 0; i < snakeSize-1; i++)
                    {
                        snake[i] = snake[i+1];
                    }

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.LIGHTGRAY);
                    for (int i = 0; i < snakeSize-1; i++){
                        Raylib.DrawRectangleRec(snake[i], Color.BLUE);  
                    }
                    
                    Raylib.EndDrawing();


            //  change dir ---------------
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
                {
                    dir = new Vector2(1, 0);
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
                {
                    dir = new Vector2(0, 1);
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
                {
                    dir = new Vector2(1, 1);
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
                {
                    dir = new Vector2(-1, -1);
                }
            //------------------------------

            // wall collision - MOVE ---------------------------
                if (framesCounter % 5 == 0)
                {
                    if (dir == new Vector2(1, 0))
                    {
                        snake[0].x -= (int)(snakeSpeed);
                        if (snake[0].x < -20)
                        {
                            snake[0].x = screenWidth;
                        }
                    }
                    if (dir == new Vector2(0, 1))
                    {
                        snake[0].x += (int)(snakeSpeed);

                        if (snake[0].x > screenWidth)
                        {
                            snake[0].x = -20;
                        }
                    }
                    if (dir == new Vector2(1, 1))
                    {
                        snake[0].y -= (int)(snakeSpeed);
                        if (snake[0].y < -20)
                        {
                            snake[0].y = screenHeight;
                        }
                    }
                    if (dir == new Vector2(-1, -1))
                    {
                        snake[0].y += (int)(snakeSpeed);
                        if (snake[0].y > screenHeight)
                        {
                            snake[0].y = -20;
                        }
                    }
                }
                //---------------------------------------



                
                // Random Food After Eat ---------------------
                if (snake[0].x == food.x && snake[0].y == food.y)
                {
                    int tempFoodX = randFoodPosition.Next(screenWidth - 20);
                    int tempFoodY = randFoodPosition.Next(screenHeight - 20);
                    food.x = tempFoodX - (tempFoodX % 20);
                    food.y = tempFoodY - (tempFoodY % 20);

                    snakeSize++;
                }
                // ---------------------------------------------------

                snake[snakeSize] = new Rectangle(snake[0].x, snake[0].y, 20, 20)

                // draw Head after update
                Raylib.BeginDrawing();
                    Raylib.DrawRectangleRec(food, Color.RED);
                    Raylib.DrawRectangleRec(snake[0], Color.BLUE);   
                Raylib.EndDrawing();

                framesCounter++;
            }


            Raylib.CloseWindow();

        }


    }
}
