# Herdsman Prototype

## Description

This project is a simple 2D prototype of a mini-game where the player can collect animals using the Main Hero and move them to the destination point (yard). 

### Features

- The player can see the game field (green area) with the Main Hero (red circle).
- Randomly positioned animals (white circles) on the game field.
- A destination point (yard) represented by a yellow area.
- A score counter displayed on the Top UI.
- The Main Hero moves to the clicked position on the game field.
- Animals follow the Main Hero when the Main Hero gets close to them, forming a group with a maximum of 5 animals.
- The score counter increases when animals reach the yard.
- Additional features include a spawn generator for animals and patrol behavior for animals.

## Tools and Technologies

- **Programming Language**: C#
- **Game Engine**: Unity 3D
- **Design Patterns**: Factory, State Machine, Pooling, Caching, Observer
- **Navigation**: Unity's NavMesh for 2D navigation

## Design Patterns and Best Practices

### Factory Pattern

Used to create different types of game objects, such as animals, to ensure scalability and manageability.

### State Machine

Implemented for the Main Hero and animal behaviors to manage their states efficiently and ensure a clear flow of actions.

### Pooling

Used to manage the spawning and reusing of animals to improve performance by reducing the overhead of instantiating and destroying objects frequently.

### Caching

Implemented to store frequently accessed data to improve performance and reduce the need for repetitive calculations or data retrieval.

### Observer

Used to manage events and interactions between different game components, ensuring a decoupled and maintainable codebase.

## Setup Instructions

1. **Clone the Repository**

   ```bash
   git clone https://github.com/PlanetaRobotos/Herdsman.git
   cd herdsman
