# Minecraft Server Launcher

A lightweight Windows application built with C# (WinForms) for managing and launching Minecraft server `.bat` files through a simple UI.

## Features

- Select the root folder containing your Minecraft server setup  
- View and edit `.bat` files from the `launchers` directory  
- Easily launch any selected `.bat` file  
- Create new `.bat` files from the interface  
- Automatically loads available `.bat` files into a dropdown list  

## Folder Structure

The application expects the following structure inside the root directory:


Minecraft Servers/
├── versions/      ← Contains individual Minecraft server folders (with .jar files, mods, configs, etc.)
└── launchers/     ← Contains .bat files used to launch servers from the versions folder

## How to Use

1. Launch the application.  
2. Click the **"Path"** button to select your root folder (`Minecraft Servers`).  
3. Select a `.bat` file from the dropdown menu.  
4. Edit the launch parameters if needed in the editor.  
5. Click **"Run"** to start the server or **"Save"** to apply changes.  
6. Use **"Add New"** to create a blank `.bat` file in the `launchers` folder. 
