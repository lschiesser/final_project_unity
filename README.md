# Final project Unity

To-Do:
- [ ] Experiment Info fertigstellen
- [ ] Ending sequence programmieren
- [ ] Issue mit prefabs, dass sie zu weit unten sind bei ShowArray (verschieden Ankerpoints)
- [ ] Randomisierung von target und distractor category

3D Modelling - mögliche Programme:
- [ProBuilder](https://docs.unity3d.com/Packages/com.unity.probuilder@4.0/manual/index.html)
- [Blender](https://www.blender.org/)

Metrics to record:
- reaction time (in ms or s)
- Verhältnis Distractor(D) Target(T): D/D+T T/D+T
- Target Typ (fear inducing or not)
- Correct or not
- subject id, block, trial
- Abfrage ob Angst vor Spinnen, Schlangen, ...?
- Position von Target aufnehmen?
 
 Stimuli:
 - 3 fear inducing animate stimuli: Spinnen, Schlangen, Wespe
 - 3 non fear inducing animate stimuli: Katze, Hund, Schmetterling/Vogel
 - 3 inanimate stimuli: Blume, Pilz, Baum
 
 |Stimulus|Gefunden|Link (wenn möglich)| Importiert |
 |--------|--------|-------------------|------------|
 | Spinne | :white_check_mark: |   https://assetstore.unity.com/packages/3d/characters/animals/animated-spiders-pack-9864  <br /> https://sketchfab.com/3d-models/realistic-spider-b89e69df279c4fe1b62179edac679617 | :white_check_mark: |
 | Schlange | :white_check_mark: | https://free3d.com/de/3d-model/rattlesnake-v04--784635.html   |  :white_check_mark:   |
 | Biene | :white_check_mark:  |   https://sketchfab.com/3d-models/bee-lowpoly-bc2078873d864db9b71f9064a935af7d | :white_check_mark:     |
 | Katze |  :white_check_mark:  |    https://assetstore.unity.com/packages/3d/characters/animals/free-chibi-cat-165490 <br />  https://free3d.com/de/3d-model/cat-v1--326682.html  | :white_check_mark: |
 | Hund |  :white_check_mark:   |    https://free3d.com/3d-model/canaan-dog-v1--72376.html     |  :white_check_mark:  |
 | Schmetterling | :white_check_mark: |  https://assetstore.unity.com/packages/3d/characters/animals/butterfly-animated-58355  <br />                          https://assetstore.unity.com/packages/3d/characters/animals/butterfly-with-animations-20985 <br /> https://sketchfab.com/3d-models/white-flower-9e025b18a39741a4a38b197cee3cdcac |  :white_check_mark:   |
 | Vogel | :white_check_mark:  | https://assetstore.unity.com/packages/3d/characters/animals/living-birds-15649  <br /> https://free3d.com/3d-model/bird-v1--875504.html |   :white_check_mark:    |
 | Blume | :white_check_mark: |  https://assetstore.unity.com/packages/3d/vegetation/plants/lowpoly-flowers-47083 <br/> https://sketchfab.com/3d-models/white-flower-9e025b18a39741a4a38b197cee3cdcac |   :white_check_mark:       |
 | Pilz |   :white_check_mark:  |     https://assetstore.unity.com/packages/3d/environments/toadstools-pack-photoscanned-70294  <br/> https://free3d.com/3d-model/mushroomshitake--119909.html | :white_check_mark:  |
 | Baum |  :white_check_mark:   |    https://assetstore.unity.com/packages/3d/vegetation/trees/realistic-tree-9-rainbow-tree-54622 <br />                                https://assetstore.unity.com/packages/3d/vegetation/trees/free-trees-103208 <br/>  https://free3d.com/3d-model/maple-tree-262328.html | :white_check_mark:  |
 
### How to import .obj-Files into Unity
Before downloading anything, create folder "ext-objects" in Assets folder (this folder is not tracked by Git)
1. Download from source (from free3d usually as .zip-File) to ext-objects folder
2. Unzip folder
3. Drag .obj-file into Scene, it is loaded into the scene as a prefab
4. Sometimes you have to unpack the prefab, so you only have the object that you want (you don't necessarily have to do this, it depends on how many objects there are in the parent)
5. Drag the object into the Prefabs folder, so we can use it later.
