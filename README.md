# ⚔️ Scalable RPG Game — Modular Architecture in Unity

This project is a **RPG-style game** built with a focus on **clean, scalable architecture** and maintainable code structure. The goal is to create a solid foundation for gameplay systems that can evolve and expand with minimal refactoring.

---

## 🏗️ Architecture & Design Principles

The game follows **SOLID principles** and separates logic into well-defined layers using the following key design patterns:

- 🗃️ **Repository–Interactor Pattern**  
  Clean separation of data access (repositories) and business logic (interactors).

- 🏭 **Factory Pattern**  
  Dynamic creation of characters, items, and gameplay entities at runtime.

- 👀 **Observer Pattern**  
  Efficient event propagation between systems without tight coupling.

- 🧠 **Dependency Injection with Zenject**  
  Modular and testable system initialization and lifecycle management.

---

## ⚙️ Tech Stack

- **Unity (2022+)**
- **C#**
- [Zenject](https://github.com/modesttree/Zenject) — Dependency Injection framework for Unity
- [UniTask](https://github.com/Cysharp/UniTask) — Lightweight async/await support for Unity
- [R3](https://github.com/Cysharp/R3) — Lightweight Reactive Extensions for Unity
