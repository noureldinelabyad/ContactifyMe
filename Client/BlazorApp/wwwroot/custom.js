window.displayActionSheet =
    (title, okButtonLabel, cancelButtonLabel, ...otherButtons) => {
    return new Promise((resolve) =>
    {
        const buttons = [okButtonLabel, cancelButtonLabel, ...otherButtons].filter(Boolean);

        const options = {
            title: title,
            destructiveButtonIndex: 2, // Index of "Delete Contact" button
            androidEnableCancelButton: true, // Show cancel button on Android
            addCancelButtonWithLabel: cancelButtonLabel, // Label for cancel button
            buttons: buttons
        };

        window.plugins.actionsheet.show(options, (buttonIndex) => {
            if (buttonIndex >= 0) {
                resolve(buttons[buttonIndex]);
            } else {
                resolve(null);
            }
        });
    });
};
