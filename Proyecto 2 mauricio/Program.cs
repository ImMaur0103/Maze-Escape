using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2_mauricio
{
    class Program
    {
        static string[,] llenar_tablero(int tamaño, string objetivo, string jugador, string enemigo, string obstaculo, int cantidad_max_obstaculos, int cantidad_max_enemigos)
        {
            string[,] tablero = new string[tamaño, tamaño];
            Random ran = new Random();
            int contador_enemigos = 0;
            int contador_obstaculos = 0;
            bool Objetivo = false;
            bool Jugador = false;
            for (int i = 0; i < tamaño; i++)
            {
                for (int j = 0; j < tamaño; j++)
                {
                    int opcion = ran.Next(1, 8);
                    if ((!Jugador || !Objetivo) && (i == tamaño - 1) && ((j == tamaño - 1) || j == -2))
                    {
                        if (!Objetivo)
                        {
                            tablero[i, j] = objetivo;
                            Objetivo = true;
                        }
                        else if (!Jugador)
                        {
                            tablero[i, j] = jugador;
                            Jugador = true;
                        }
                    }
                    else if (opcion == 1 && !Jugador)
                    {
                        tablero[i, j] = jugador;
                        Jugador = true;
                    }
                    else if (opcion == 2 && !Objetivo)
                    {
                        tablero[i, j] = objetivo;
                        Objetivo = true;
                    }
                    else if ((opcion == 3 || opcion == 4) && (contador_enemigos < cantidad_max_enemigos))
                    {
                        tablero[i, j] = enemigo;
                        contador_enemigos++;
                    }
                    else if ((opcion == 5 || opcion == 6) && (contador_obstaculos < cantidad_max_obstaculos))
                    {
                        tablero[i, j] = obstaculo;
                        contador_obstaculos++;
                    }
                    else
                    {
                        tablero[i, j] = " ";
                    }
                }
            }
            return tablero;
        }
        static void Main(string[] args)
        {
            const string personaje = "§";
            const string estrella = "º";
            const string enemigo = "X";
            const string obstaculo = "■";
            string name = "";
            string col = "";
            bool partida = true;
            int vida = 0;
            int color;
            do
            {
                Console.WriteLine("Bienvenido a Maze escape \nSi desea jugar precione enter, si desea salir precione escape");
                var tecla = Console.ReadKey();
                while(tecla.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("1) Ingresar nombre del personaje\n2) Jugar\n3) Salir");
                    string op = Console.ReadLine();
                    if(op == "3")
                    {
                        break;
                    }
                    if(op == "1")
                    {
                        Console.WriteLine("Ingrese nombre del personaje");
                        name = Console.ReadLine();
                        Console.WriteLine("Ingrese color para personaje");
                        Console.WriteLine("1. Rojo\n2. Verde\n3. Amarillo\n4. Rosado");
                        color = Convert.ToInt32(Console.ReadLine());
                        switch (color)
                        {

                            case 1:
                                col = "rojo";
                                break;
                            case 2:
                                col = "verde";
                                break;
                            case 3:
                                col = "amarillo";
                                break;
                            case 4:
                                col = "rosado";
                                break;

                        }
                        Console.Clear();
                    }
                    if(op == "2")
                    {
                        while(partida)
                        {
                            bool gano = false;
                            Console.WriteLine("si Desea jugar en algun tablero precione:");
                            Console.WriteLine("a) tablero 7X7");
                            Console.WriteLine("b) tablero 10X10");
                            Console.WriteLine("c) tablero 25X25");
                            Console.WriteLine("Si desea salir precione d");
                            string op1 = Console.ReadLine();
                            if (op1 == "d")
                            {
                                break;
                            }
                            while (op1 == "a")
                            {
                                int tamaño = 7;
                                int cantidad_de_enemigos = 10;
                                int cantidad_de_obstaculos = 15;
                                string[,] tablero = new string[tamaño, tamaño];
                                tablero = llenar_tablero(tamaño, estrella, personaje, enemigo, obstaculo, cantidad_de_obstaculos, cantidad_de_enemigos);
                                vida = 3;
                                bool cheadcode = false;
                                while(!gano)
                                {
                                    for (int i = -1; i <= tamaño; i++)
                                    {   
                                        for (int j = -1; j <= tamaño; j++)
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            if ((i == -1 && j == -1) || (i == tamaño && j == tamaño) || (i == tamaño && j == -1) || (i == -1 && j == tamaño))
                                            {
                                                Console.Write("#");
                                            }
                                            else if ((i == -1) || (i == tamaño))
                                            {
                                                Console.Write("-");
                                            }
                                            else if ((j == -1) || (j == tamaño))
                                            {
                                                Console.Write("|");
                                            }
                                            else if (tablero[i, j] == personaje)
                                            {
                                                switch (col)
                                                {
                                                    case "rojo":
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        break;
                                                    case "verde":
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        break;
                                                    case "amarillo":
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        break;
                                                    case "rosado":
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        break;
                                                }
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == estrella)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == enemigo)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else
                                            {
                                                Console.Write(tablero[i, j]);
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    int posicion_x = 0;
                                    int posicion_y = 0;
                                    for (int i = 0; i < tamaño; i++)
                                    {
                                        for (int j = 0; j < tamaño; j++)
                                        {
                                            posicion_y = i;
                                            posicion_x = j;
                                            if (tablero[i, j] == personaje)
                                            {
                                                i = tamaño;
                                                break;
                                            }
                                        }
                                    }
                                    Console.WriteLine("0 = Obstaculos \tPersonaje: " + name + "\nX = Enemigos \t" + name + " Estatus del jugador: " + vida + " puntos de vida \n& = personaje\n$ = princesa");
                                    Console.WriteLine();
                                    Console.WriteLine("a) Comandos");
                                    Console.WriteLine("b) Imprimir tablero");
                                    Console.WriteLine("c) cheadcode");
                                    Console.WriteLine("d) Terminar partida");
                                    string op2 = Console.ReadLine();
                                    if (op2 == "d")
                                    {
                                        break;
                                    }
                                    while (op2 == "c")
                                    {
                                        var tecla1 = Console.ReadKey();
                                        if(tecla1.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla2 = Console.ReadKey();
                                        if (tecla2.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla3 = Console.ReadKey();
                                        if (tecla3.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla4 = Console.ReadKey();
                                        if (tecla4.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla5 = Console.ReadKey();
                                        if (tecla5.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla6 = Console.ReadKey();
                                        if (tecla6.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla7 = Console.ReadKey();
                                        if (tecla7.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla8 = Console.ReadKey();
                                        if (tecla8.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla9 = Console.ReadKey();
                                        if (tecla9.Key != ConsoleKey.B)
                                        {
                                            break;
                                        }
                                        var tecla10 = Console.ReadKey();
                                        if (tecla10.Key == ConsoleKey.A )
                                        {
                                            cheadcode = true;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    if (op2 == "b")
                                    {
                                        Console.WriteLine("El tablero anterior se compone de las siguientes coordenadas:");
                                        for (int i = 0; i < tamaño; i++)
                                        {
                                            for (int j = 0; j < tamaño; j++)
                                            {
                                                switch (tablero[i, j])
                                                {
                                                    case "&":
                                                        Console.Write("(" + i + "," + j + ") " + name + ".");
                                                        break;
                                                    case "$":
                                                        Console.Write("(" + i + "," + j + ") Princesa.");
                                                        break;
                                                    case " ":
                                                        Console.Write("(" + i + "," + j + ") Vacío.");
                                                        break;
                                                    case "X":
                                                        Console.Write("(" + i + "," + j + ") Enemigo.");
                                                        break;
                                                    case "0":
                                                        Console.Write("(" + i + "," + j + ") Obstaculo.");
                                                        break;
                                                }
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.ReadLine();
                                    }
                                    if (op2 == "a")
                                    {
                                        Console.WriteLine("ingrese la opcion deseada");
                                        Console.WriteLine("(flecha arriba) Mover arriba");
                                        Console.WriteLine("(flecha derecha) Mover derecha");
                                        Console.WriteLine("(flecha izquierda) Mover izquierda");
                                        Console.WriteLine("(flecha abajo) Mover abajo ");
                                        Console.WriteLine();
                                        Console.WriteLine("(z) para atacar y luego precione la direccion ");
                                        var tecla1 = Console.ReadKey();
                                        switch (tecla1.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                if (posicion_y != 0)
                                                {
                                                    if (tablero[posicion_y - 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y - 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.DownArrow:
                                                if (posicion_y != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y + 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y + 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.RightArrow:
                                                if (posicion_x != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y, posicion_x + 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x + 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.LeftArrow:
                                                if (posicion_x != 0)
                                                {
                                                    if (tablero[posicion_y, posicion_x - 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x - 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = true;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.Z:
                                                Console.WriteLine("Ingreso disparar.\nSeleccione la direccion de disparo");
                                                tecla1 = Console.ReadKey();
                                                switch (tecla1.Key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (posicion_y != 0)
                                                        {
                                                            if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y - 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (posicion_y != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y + 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.RightArrow:
                                                        if (posicion_x != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x + 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        if (posicion_x != 0)
                                                        {
                                                            if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x - 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                }
                                                break;
                                        }
                                    }
                                    Console.Clear();
                                    if(cheadcode)
                                    {
                                        vida = 999;
                                    }
                                    if (vida == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Game Over");
                                        break;
                                    }
                                }
                                if(!gano)
                                {
                                    break;
                                }
                                if(vida == 0)
                                {
                                    break;
                                }
                            }
                            while (op1 == "b")
                            {
                                int tamaño = 10;
                                int cantidad_de_enemigos = 30;
                                int cantidad_de_obstaculos = 50;
                                string[,] tablero = new string[tamaño, tamaño];
                                tablero = llenar_tablero(tamaño, estrella, personaje, enemigo, obstaculo, cantidad_de_obstaculos, cantidad_de_enemigos);
                                vida = 3;
                                bool cheadcode = false;
                                while (!gano)
                                {
                                    for (int i = -1; i <= tamaño; i++)
                                    {
                                        for (int j = -1; j <= tamaño; j++)
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            if ((i == -1 && j == -1) || (i == tamaño && j == tamaño) || (i == tamaño && j == -1) || (i == -1 && j == tamaño))
                                            {
                                                Console.Write("#");
                                            }
                                            else if ((i == -1) || (i == tamaño))
                                            {
                                                Console.Write("-");
                                            }
                                            else if ((j == -1) || (j == tamaño))
                                            {
                                                Console.Write("|");
                                            }
                                            else if (tablero[i, j] == personaje)
                                            {
                                                switch (col)
                                                {
                                                    case "rojo":
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        break;
                                                    case "verde":
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        break;
                                                    case "amarillo":
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        break;
                                                    case "rosado":
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        break;
                                                }
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == estrella)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == enemigo)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else
                                            {
                                                Console.Write(tablero[i, j]);
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    int posicion_x = 0;
                                    int posicion_y = 0;
                                    for (int i = 0; i < tamaño; i++)
                                    {
                                        for (int j = 0; j < tamaño; j++)
                                        {
                                            posicion_y = i;
                                            posicion_x = j;
                                            if (tablero[i, j] == personaje)
                                            {
                                                i = tamaño;
                                                break;
                                            }
                                        }
                                    }
                                    Console.WriteLine("0 = Obstaculos \tPersonaje: " + name + "\nX = Enemigos \t" + name + " Estatus del jugador: " + vida + " puntos de vida \n& = personaje\n$ = princesa");
                                    Console.WriteLine();
                                    Console.WriteLine("a) Comandos");
                                    Console.WriteLine("b) Imprimir tablero");
                                    Console.WriteLine("c) cheadcode");
                                    Console.WriteLine("d) Terminar partida");
                                    string op2 = Console.ReadLine();
                                    if (op2 == "d")
                                    {
                                        break;
                                    }
                                    while (op2 == "c")
                                    {
                                        var tecla1 = Console.ReadKey();
                                        if (tecla1.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla2 = Console.ReadKey();
                                        if (tecla2.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla3 = Console.ReadKey();
                                        if (tecla3.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla4 = Console.ReadKey();
                                        if (tecla4.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla5 = Console.ReadKey();
                                        if (tecla5.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla6 = Console.ReadKey();
                                        if (tecla6.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla7 = Console.ReadKey();
                                        if (tecla7.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla8 = Console.ReadKey();
                                        if (tecla8.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla9 = Console.ReadKey();
                                        if (tecla9.Key != ConsoleKey.B)
                                        {
                                            break;
                                        }
                                        var tecla10 = Console.ReadKey();
                                        if (tecla10.Key == ConsoleKey.A)
                                        {
                                            cheadcode = true;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    if (op2 == "b")
                                    {
                                        Console.WriteLine("El tablero anterior se compone de las siguientes coordenadas:");
                                        for (int i = 0; i < tamaño; i++)
                                        {
                                            for (int j = 0; j < tamaño; j++)
                                            {
                                                switch (tablero[i, j])
                                                {
                                                    case "&":
                                                        Console.Write("(" + i + "," + j + ") " + name + ".");
                                                        break;
                                                    case "$":
                                                        Console.Write("(" + i + "," + j + ") Princesa.");
                                                        break;
                                                    case " ":
                                                        Console.Write("(" + i + "," + j + ") Vacío.");
                                                        break;
                                                    case "X":
                                                        Console.Write("(" + i + "," + j + ") Enemigo.");
                                                        break;
                                                    case "0":
                                                        Console.Write("(" + i + "," + j + ") Obstaculo.");
                                                        break;
                                                }
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.ReadLine();
                                    }
                                    if (op2 == "a")
                                    {
                                        Console.WriteLine("ingrese la opcion deseada");
                                        Console.WriteLine("(flecha arriba) Mover arriba");
                                        Console.WriteLine("(flecha derecha) Mover derecha");
                                        Console.WriteLine("(flecha izquierda) Mover izquierda");
                                        Console.WriteLine("(flecha abajo) Mover abajo ");
                                        Console.WriteLine();
                                        Console.WriteLine("(z) para atacar y luego precione la direccion ");
                                        var tecla1 = Console.ReadKey();
                                        switch (tecla1.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                if (posicion_y != 0)
                                                {
                                                    if (tablero[posicion_y - 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y - 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.DownArrow:
                                                if (posicion_y != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y + 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y + 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.RightArrow:
                                                if (posicion_x != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y, posicion_x + 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x + 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.LeftArrow:
                                                if (posicion_x != 0)
                                                {
                                                    if (tablero[posicion_y, posicion_x - 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x - 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = true;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.Z:
                                                Console.WriteLine("Ingreso disparar.\nSeleccione la direccion de disparo");
                                                tecla1 = Console.ReadKey();
                                                switch (tecla1.Key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (posicion_y != 0)
                                                        {
                                                            if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y - 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (posicion_y != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y + 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.RightArrow:
                                                        if (posicion_x != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x + 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        if (posicion_x != 0)
                                                        {
                                                            if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x - 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                }
                                                break;
                                        }
                                    }
                                    Console.Clear();
                                    if (cheadcode)
                                    {
                                        vida = 999;
                                    }
                                    if (vida == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Game Over");
                                        break;
                                    }
                                }
                                if (!gano)
                                {
                                    break;
                                }
                                if (vida == 0)
                                {
                                    break;
                                }
                            }
                            while (op1 == "c")
                            {
                                int tamaño = 10;
                                int cantidad_de_enemigos = 30;
                                int cantidad_de_obstaculos = 50;
                                string[,] tablero = new string[tamaño, tamaño];
                                tablero = llenar_tablero(tamaño, estrella, personaje, enemigo, obstaculo, cantidad_de_obstaculos, cantidad_de_enemigos);
                                vida = 3;
                                bool cheadcode = false;
                                while (!gano)
                                {
                                    for (int i = -1; i <= tamaño; i++)
                                    {
                                        for (int j = -1; j <= tamaño; j++)
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            if ((i == -1 && j == -1) || (i == tamaño && j == tamaño) || (i == tamaño && j == -1) || (i == -1 && j == tamaño))
                                            {
                                                Console.Write("#");
                                            }
                                            else if ((i == -1) || (i == tamaño))
                                            {
                                                Console.Write("-");
                                            }
                                            else if ((j == -1) || (j == tamaño))
                                            {
                                                Console.Write("|");
                                            }
                                            else if (tablero[i, j] == personaje)
                                            {
                                                switch (col)
                                                {
                                                    case "rojo":
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        break;
                                                    case "verde":
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        break;
                                                    case "amarillo":
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        break;
                                                    case "rosado":
                                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                                        break;
                                                }
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == estrella)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else if (tablero[i, j] == enemigo)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                Console.Write(tablero[i, j]);
                                            }
                                            else
                                            {
                                                Console.Write(tablero[i, j]);
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                    int posicion_x = 0;
                                    int posicion_y = 0;
                                    for (int i = 0; i < tamaño; i++)
                                    {
                                        for (int j = 0; j < tamaño; j++)
                                        {
                                            posicion_y = i;
                                            posicion_x = j;
                                            if (tablero[i, j] == personaje)
                                            {
                                                i = tamaño;
                                                break;
                                            }
                                        }
                                    }
                                    Console.WriteLine("0 = Obstaculos \tPersonaje: " + name + "\nX = Enemigos \t" + name + " Estatus del jugador: " + vida + " puntos de vida \n& = personaje\n$ = princesa");
                                    Console.WriteLine();
                                    Console.WriteLine("a) Comandos");
                                    Console.WriteLine("b) Imprimir tablero");
                                    Console.WriteLine("c) cheadcode");
                                    Console.WriteLine("d) Terminar partida");
                                    string op2 = Console.ReadLine();
                                    if (op2 == "d")
                                    {
                                        break;
                                    }
                                    while (op2 == "c")
                                    {

                                        var tecla1 = Console.ReadKey();
                                        if (tecla1.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla2 = Console.ReadKey();
                                        if (tecla2.Key != ConsoleKey.UpArrow)
                                        {
                                            break;
                                        }
                                        var tecla3 = Console.ReadKey();
                                        if (tecla3.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla4 = Console.ReadKey();
                                        if (tecla4.Key != ConsoleKey.DownArrow)
                                        {
                                            break;
                                        }
                                        var tecla5 = Console.ReadKey();
                                        if (tecla5.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla6 = Console.ReadKey();
                                        if (tecla6.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla7 = Console.ReadKey();
                                        if (tecla7.Key != ConsoleKey.LeftArrow)
                                        {
                                            break;
                                        }
                                        var tecla8 = Console.ReadKey();
                                        if (tecla8.Key != ConsoleKey.RightArrow)
                                        {
                                            break;
                                        }
                                        var tecla9 = Console.ReadKey();
                                        if (tecla9.Key != ConsoleKey.B)
                                        {
                                            break;
                                        }
                                        var tecla10 = Console.ReadKey();
                                        if (tecla10.Key == ConsoleKey.A)
                                        {
                                            cheadcode = true;
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    if (op2 == "b")
                                    {
                                        Console.WriteLine("El tablero anterior se compone de las siguientes coordenadas:");
                                        for (int i = 0; i < tamaño; i++)
                                        {
                                            for (int j = 0; j < tamaño; j++)
                                            {
                                                switch (tablero[i, j])
                                                {
                                                    case "&":
                                                        Console.Write("(" + i + "," + j + ") " + name + ".");
                                                        break;
                                                    case "$":
                                                        Console.Write("(" + i + "," + j + ") Princesa.");
                                                        break;
                                                    case " ":
                                                        Console.Write("(" + i + "," + j + ") Vacío.");
                                                        break;
                                                    case "X":
                                                        Console.Write("(" + i + "," + j + ") Enemigo.");
                                                        break;
                                                    case "0":
                                                        Console.Write("(" + i + "," + j + ") Obstaculo.");
                                                        break;
                                                }
                                            }
                                            Console.WriteLine();
                                        }
                                        Console.ReadLine();
                                    }
                                    if (op2 == "a")
                                    {
                                        Console.WriteLine("ingrese la opcion deseada");
                                        Console.WriteLine("(flecha arriba) Mover arriba");
                                        Console.WriteLine("(flecha derecha) Mover derecha");
                                        Console.WriteLine("(flecha izquierda) Mover izquierda");
                                        Console.WriteLine("(flecha abajo) Mover abajo ");
                                        Console.WriteLine();
                                        Console.WriteLine("(z) para atacar y luego precione la direccion ");
                                        var tecla1 = Console.ReadKey();
                                        switch (tecla1.Key)
                                        {
                                            case ConsoleKey.UpArrow:
                                                if (posicion_y != 0)
                                                {
                                                    if (tablero[posicion_y - 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y - 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y - 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.DownArrow:
                                                if (posicion_y != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y + 1, posicion_x] == " ")
                                                    {
                                                        tablero[posicion_y + 1, posicion_x] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y + 1, posicion_x] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.RightArrow:
                                                if (posicion_x != tamaño - 1)
                                                {
                                                    if (tablero[posicion_y, posicion_x + 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x + 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x + 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.LeftArrow:
                                                if (posicion_x != 0)
                                                {
                                                    if (tablero[posicion_y, posicion_x - 1] == " ")
                                                    {
                                                        tablero[posicion_y, posicion_x - 1] = personaje;
                                                        tablero[posicion_y, posicion_x] = " ";
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == obstaculo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un obstaculo en esa direccion");
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                    {
                                                        Console.WriteLine("No se puede mover, hay un enemigo en esa direccion y le ha echo un ataque critico");
                                                        vida--;
                                                        Console.ReadLine();
                                                    }
                                                    if (tablero[posicion_y, posicion_x - 1] == estrella)
                                                    {
                                                        Console.WriteLine("En hora buena, ha conseguido salvar a celestia la princesa");
                                                        Console.ReadLine();
                                                        gano = true;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No se puede mover, esta intentando salir del tablero");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case ConsoleKey.Z:
                                                Console.WriteLine("Ingreso disparar.\nSeleccione la direccion de disparo");
                                                tecla1 = Console.ReadKey();
                                                switch (tecla1.Key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (posicion_y != 0)
                                                        {
                                                            if (tablero[posicion_y - 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y - 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (posicion_y != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y + 1, posicion_x] == enemigo)
                                                            {
                                                                tablero[posicion_y + 1, posicion_x] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.RightArrow:
                                                        if (posicion_x != tamaño - 1)
                                                        {
                                                            if (tablero[posicion_y, posicion_x + 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x + 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        if (posicion_x != 0)
                                                        {
                                                            if (tablero[posicion_y, posicion_x - 1] == enemigo)
                                                            {
                                                                tablero[posicion_y, posicion_x - 1] = " ";
                                                            }
                                                        }
                                                        break;
                                                }
                                                break;
                                        }
                                    }
                                    Console.Clear();
                                    if (cheadcode)
                                    {
                                        vida = 999;
                                    }
                                    if (vida == 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Game Over");
                                        break;
                                    }
                                }
                                if (!gano)
                                {
                                    break;
                                }
                                if (vida == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                if(tecla.Key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (true);
        }
    }
}
