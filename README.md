# PedCount

## Installation
* Extract the cloned file

## Operation:
### To Count Pedestrians:
1. Run Pedcount.exe to start the application.
2. Load an image (image with pedestrians)
3. Click on Count

### To Train the model:
1. Load an image(image with pedestrians)
2. Click Annotate.
3. Click the left mouse button and drag to draw rectangles where pedestrians are present.
4. After Completing annotation click done.
5. Click Train to train the model
6. Maximum 100 images are allowed to train (Nanonets API is used for training. It can give good accuracy with 100 images).

### To Check Status of the Model:
1.Click on Check Status

* C# Code can be found in Source folders.
* Python Scripts will be in nanonets pedestrian detection

