using System;
using System.Collections.Generic;
using UnityEngine;

public class SistemaTurnosDobleEnlace : MonoBehaviour
{
    #region Clase Personaje
    public class Personaje
    {
        #region Private
        private string nombre;
        private int velocidad;
        #endregion

        #region Contructor
        public Personaje(string nombre, int velocidad)
        {
            this.nombre = nombre;
            this.velocidad = velocidad;
        }
        #endregion

        #region Getters
        public string Nombre => nombre;  
        public int Velocidad => velocidad;  
        #endregion
    }
    #endregion

    #region Variables y métodos de la clase SistemaTurnosDobleEnlace
    private LinkedList<Personaje> personajes = new LinkedList<Personaje>();

    void Start()
    {
        // Agregar personajes
        InsertarOrdenado(new Personaje("Héroe", 15));
        InsertarOrdenado(new Personaje("Enemigo1", 10));
        InsertarOrdenado(new Personaje("Mago", 20));
        InsertarOrdenado(new Personaje("Arquero", 13));

        Debug.Log("Orden de Turnos basado en Velocidad (Lista Doble Enlace):");
        MostrarYEliminarTurnos();
    }

    void InsertarOrdenado(Personaje nuevo)
    {
        if (personajes.Count == 0)
        {
            personajes.AddFirst(nuevo);
        }
        else
        {
            LinkedListNode<Personaje> actual = personajes.First;

            while (actual != null && actual.Value.Velocidad >= nuevo.Velocidad)
            {
                actual = actual.Next;
            }

            if (actual == null)
            {
                personajes.AddLast(nuevo);
            }
            else
            {
                personajes.AddBefore(actual, nuevo);
            }
        }
    }

    void MostrarYEliminarTurnos()
    {
        while (personajes.Count > 0)
        {
            LinkedListNode<Personaje> actual = personajes.First;
            // Usando las propiedades automáticas para acceder
            Debug.Log(actual.Value.Nombre + " (Velocidad: " + actual.Value.Velocidad + ") tiene su turno.");
            personajes.RemoveFirst();
        }

        Debug.Log("Todos los personajes han usado su turno.");
    }
    #endregion
}

