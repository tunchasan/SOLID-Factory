# Project: SOLID Factory
 
**SOLID Factory** is an Unity2D Project which has been developed to test high-level programming concepts such as ***SOLID***, ***DRY***, ***Separation of Concern***, ***Composition over Inheritance***, ***Maximize Cohesion***, ***Minimize Coupling***, and ***Dependency Injection(Exzenject)*** principles in Unity.

I separated the project into two layers. The first layer is the **Core**, which contains whole gameplay and systems implementations. The last layer is **Simulation** which I have designed for simulating the Core layer.

You can find the layers with these directories:
```Core Layer : Assets/Scripts/Core```
```Simulation Layer : Assets/Scripts/Simulation```

Also, you can run the **Simulation Scene** which is in the ```Assets/Scenes/Simulation``` directory. When you hit play, the simulation will add 12 scenes. You can zoom in and out by clicking the frame that holds a scene. When you zoom in on a scene, other scenes unload. The load and unload scene operations work async. This significantly reduces the processing intensity.

### Stable Tank

> **Stable Tank with the lowest specs. Tanks cannot move around. However, they are only capable of detecting and tracking things.**

![Stabletank-1](https://user-images.githubusercontent.com/39636292/177788876-03959ef1-bd14-438f-91ca-fc6121a93e49.gif)

### Mobile Tank

> **Fastest tank kind. Mobile Tanks can move around quickly. However, they are only capable of detecting things and navigating around.**

![Mobiletank-1](https://user-images.githubusercontent.com/39636292/177789231-2a168635-4299-4646-8386-9067ba17bad1.gif)

### Sources

> **The Source is an entity to which we can apply five different behaviors with the Composition over Inheritance principle. There is possible to create 48 variant sources whose different sub-behaviors than the others. Also, it's possible to make that combination at runtime!**

![Source-1](https://user-images.githubusercontent.com/39636292/177789387-23f7e2aa-893a-4ce7-a1a1-52a5ab48f370.gif)


### Heavy Tank

> **The most capable Tank kind. Heavy Tanks are slower than Mobile Tanks. However, there is the Placer Unit, which gives the ability to store and place entities. They are also capable of detecting things and navigating around.**

![Heavytank-1](https://user-images.githubusercontent.com/39636292/177789615-ef0b8336-e672-4abd-978d-b929ee2ca0b7.gif)

### Placeable Area

> **Placeable Areas can be detectable by any Tank kind whose a Detector Unit. The Area executes its operation with the entity that has IPlaceable behavior. Also, the Area has two different placement types. The first one organizes received entities with specific animation. The last one places the entities where they've received without any action.**

![Placearea-1](https://user-images.githubusercontent.com/39636292/177789837-bbb6806d-370d-49f7-bfd9-f9426fa51d9d.gif)

### ConveyorBelt

> **Conveyor Belts are only capable of carrying entities whose ITransportable behavior. Every received transportable entity keeps in Queue until the next iteration of the Conveyor Belt starts.**

![Conveyor-1](https://user-images.githubusercontent.com/39636292/177789930-c9509669-ee52-4c1a-a1cd-2f6cd441184b.gif)

### Sprayer

> **Sprayers are only capable of spraying entities which has IPlaceable behavior. Every received transportable entity keeps in Queue until the next iteration of Sprayer starts. The Circle is the default Sprayer's target area. It's easy to create new variations like Triangle, Square, etc. Also, the area radius is changeable via Inspector with the "radius" property.**

![Sprayer](https://user-images.githubusercontent.com/39636292/177790048-e9ce7b3a-cd16-4abd-a148-0fbc6fe7e73e.gif)

### Processor

> **Processor is only capable of upgrading entities' sub-behaviors whose IProcessable behavior. Every received processable entity keeps in Queue until the next iteration of the Processor starts. In the example, the Processor doesn't process the entity which doesn't have IProcessable behavior. That's why the entities are stuck in Processor's entry point.**

![Processor](https://user-images.githubusercontent.com/39636292/177790092-44c3f758-f51c-48aa-a752-f9657bf4e798.gif)

### Straight Machines

> **Every individual component is processed as Node. It is a module whose Input, Process, and Output operations are implementations. Straight Machine searches for its child elements to find Nodes. Then, bind found nodes to each other such as the Singly Linked List approach.**

![Straight-Machine](https://user-images.githubusercontent.com/39636292/177790202-f988fca6-e75f-48c1-9ffb-d9e9ce37fe63.gif)


### Cyclic Machines

> **The Loop Machine works pretty much the same as the Straight Machine. But the only difference is that the machine uses the Circular Linked List approach. In this way, it is possible to create cyclic machines.**

![Loop-Machine](https://user-images.githubusercontent.com/39636292/177790439-927487e7-259f-47a5-9aee-979d7c5dafbc.gif)

### Showcase

![Showcase](https://user-images.githubusercontent.com/39636292/177790525-9f3b4cd6-837f-47c2-9fc3-6d49f5e937e6.gif)
