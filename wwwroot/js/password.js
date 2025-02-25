var elements = document.getElementsByClassName('showPassword');
for (var i = 0; i < elements.length; i++) {
    elements[i].addEventListener('click', function () {
        console.log('id ' + this.id);

        var field = this.id === 'togglePassword' ? 'password' : 'confirm-password';

        var passwordField = document.getElementById(field);
        var type = passwordField.getAttribute('type') === 'password' ? 'text' : 'password';

        passwordField.setAttribute('type', type);

        var toggle = document.getElementById(this.id);

        var icon = toggle.classList.contains('fa-eye') ? 'fa-eye-slash' : 'fa-eye';

        switch (icon) {
            case 'fa-eye-slash':
                toggle.classList.remove('fa-eye');
                toggle.classList.add('fa-eye-slash');
                break;
            case 'fa-eye':
                toggle.classList.remove('fa-eye-slash');
                toggle.classList.add('fa-eye');
                break;
        }
        console.log(icon);
    });
}