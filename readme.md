# d4c-emu - Nintendo Content Delivery server emulator

This is my implementation of the nintendo online services made with ASP.NET.

It can currently emulate the following services:

- [x] sun
- [x] aqua
- [x] atumn
- [ ] atum
- [ ] superfly

## Usage:
### Setup server
To configure the server you have to create a folder where the executable 
is located called `contents` and place the ncas there, you also need to 
copy your **keys file** in the same folder of the executable.

### Setup Switch
You need to use the patch a patch to disable certificate verification 
you can get it here: [exefs_patches](https://github.com/misson20000/exefs_patches) by misson20000 
and redirect the calls to your server ip 
(dns redirection, proxy, etc...).

## Credits
* **[Switchbrew](https://switchbrew.org/)** - For all documentation in the Network section.
* **[misson20000](https://github.com/misson20000/)** - For his patches.
* **[Thealexbarney](https://github.com/Thealexbarney/LibHac)** - For LibHac