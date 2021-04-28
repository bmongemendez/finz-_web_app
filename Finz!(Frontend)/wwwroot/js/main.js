const eyePassword = document.querySelectorAll('.form__password-eye');
const inputPassword = document.querySelectorAll('.form__password');
eyePassword &&
	eyePassword.forEach((element, index) => {
		element.addEventListener('click', () => {
			inputPassword[index].type =
				inputPassword[index].type === 'password' ? 'text' : 'password';
			eyePassword[index].classList.toggle('form__password-eye--hide');
		});
	});


