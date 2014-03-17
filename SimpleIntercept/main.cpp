#include <iostream>
#include <ios>

#include "interception.h"
#include "utils.h"

enum ScanCode
{
    SCANCODE_X   = 0x2D,
    SCANCODE_Y   = 0x15,
    SCANCODE_ESC = 0x01
};

int main()
{

	using namespace std;

    InterceptionContext context;
    InterceptionDevice device;
    InterceptionStroke stroke;

	wchar_t hardware_id[500]; // declare variable to store the hardware id of the device

    raise_process_priority();

    context = interception_create_context();

    interception_set_filter(context, interception_is_keyboard, INTERCEPTION_FILTER_KEY_DOWN | INTERCEPTION_FILTER_KEY_UP);
    interception_set_filter(context, interception_is_mouse, INTERCEPTION_FILTER_MOUSE_LEFT_BUTTON_DOWN);

    while(interception_receive(context, device = interception_wait(context), &stroke, 1) > 0)
    {
        if(interception_is_keyboard(device))
        {
            InterceptionKeyStroke &keystroke = *(InterceptionKeyStroke *) &stroke;
			cout << "INTERCEPTION_KEYBOARD(" << device - INTERCEPTION_KEYBOARD(0) << ")" << endl;

			//swallow events from keyboard 3
			//if(device - INTERCEPTION_KEYBOARD(0) != 3){interception_send(context, device, &stroke, 1);}

			size_t length = interception_get_hardware_id(context, device, hardware_id, sizeof(hardware_id));
			
			if(length > 0 && length < sizeof(hardware_id))
				wcout << hardware_id << endl;
            
			if(keystroke.code == SCANCODE_ESC) break;
			
			// comment the following line and uncomment the one above to swallow the input
			// note, this will break debugging and cause issues if you are unprepared.
			interception_send(context, device, &stroke, 1);
        }

        if(interception_is_mouse(device))
        {
            InterceptionMouseStroke &mousestroke = *(InterceptionMouseStroke *) &stroke;

            cout << "INTERCEPTION_MOUSE(" << device - INTERCEPTION_MOUSE(0) << ")" << endl;
			
			interception_send(context, device, &stroke, 1);
        }

        
    }

    interception_destroy_context(context);

    return 0;
}