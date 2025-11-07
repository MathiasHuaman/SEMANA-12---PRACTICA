using System;

namespace Semana12
{
    class Libreria
    {
        private string[] nombres = new string[100];
        private decimal[] precios = new decimal[100];
        private int contador = 0;

        public void Registrar()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR LIBRO ---");

            if (contador >= 100)
            {
                Console.WriteLine("La librería está llena.");
                return;
            }

            Console.Write("Ingrese el nombre del libro: ");
            string nombre = Console.ReadLine();

            if (nombre == "")
            {
                Console.WriteLine("El nombre no puede estar vacío.");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre.ToLower())
                {
                    Console.WriteLine("Ese libro ya está registrado.");
                    return;
                }
            }

            Console.Write("Ingrese el precio del libro: ");
            string entrada = Console.ReadLine();
            decimal precio;

            if (!decimal.TryParse(entrada, out precio))
            {
                Console.WriteLine("El precio debe ser numérico.");
                return;
            }

            if (precio < 0 || precio > 1000)
            {
                Console.WriteLine("El precio debe ser positivo y menor o igual a 1000.");
                return;
            }

            nombres[contador] = nombre;
            precios[contador] = precio;
            contador++;

            Console.WriteLine("Libro registrado correctamente.");
        }

        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE LIBROS ---");

            if (contador == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/. {precios[i]}");
            }
        }

        public void Modificar()
        {
            Console.Clear();
            Console.WriteLine("--- MODIFICAR LIBRO ---");

            if (contador == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("\nLIBROS REGISTRADOS:");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/. {precios[i]}");
            }

            Console.Write("\nIngrese el nombre del libro a modificar: ");
            string buscar = Console.ReadLine();
            int pos = -1;

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == buscar.ToLower())
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("No se encontró el libro.");
                return;
            }

            Console.Write($"Nuevo nombre ({nombres[pos]}): ");
            string nuevoNombre = Console.ReadLine();
            if (nuevoNombre == "") nuevoNombre = nombres[pos];

            Console.Write($"Nuevo precio (S/. {precios[pos]}): ");
            string entrada = Console.ReadLine();
            decimal nuevoPrecio;

            if (entrada == "")
                nuevoPrecio = precios[pos];
            else if (!decimal.TryParse(entrada, out nuevoPrecio) || nuevoPrecio < 0 || nuevoPrecio > 1000)
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            nombres[pos] = nuevoNombre;
            precios[pos] = nuevoPrecio;

            Console.WriteLine("Libro modificado correctamente.");
        }

        public void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("\n--- ELIMINAR LIBRO ---");

            if (contador == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("\nLIBROS REGISTRADOS:\n");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - S/. {precios[i]}");
            }

            Console.WriteLine("\n----------------------");

            Console.Write("\nIngrese el nombre del libro a eliminar: ");
            string buscar = Console.ReadLine();
            int pos = -1;

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == buscar.ToLower())
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("No se encontró el libro.");
                return;
            }

            for (int i = pos; i < contador - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
            }

            contador--;
            Console.WriteLine("Libro eliminado correctamente.");
        }


        class Libreria
        {
            static void Main()
            {
                Semana12.Libreria libreria = new Semana12.Libreria();
                int opcion;

                do
                {
                    Console.Clear();
                    Console.WriteLine("\n--- MENÚ LIBRERÍA ---\n");
                    Console.WriteLine("[1]. Registrar libro");
                    Console.WriteLine("[2]. Mostrar libros");
                    Console.WriteLine("[3]. Modificar libro");
                    Console.WriteLine("[4]. Eliminar libro");
                    Console.WriteLine("[5]. Salir\n");
                    Console.Write("Seleccione una opción: ");

                    if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        continue;
                    }

                    switch (opcion)
                    {
                        case 1: libreria.Registrar(); break;
                        case 2: libreria.Mostrar(); break;
                        case 3: libreria.Modificar(); break;
                        case 4: libreria.Eliminar(); break;
                        case 5: Console.WriteLine("Saliendo del programa..."); break;
                        default: Console.WriteLine("Opción no válida."); break;
                    }

                    if (opcion != 5)
                    {
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                    }

                } while (opcion != 5);
            }
        }
    }
}
