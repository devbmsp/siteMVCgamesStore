
let itens = [
   
];

function renderItem(item) {
    const cardWrapper = document.querySelector('.card-wrapper');

    const card = document.createElement('div');
    card.classList.add('card-item');
    card.setAttribute('id', `card${item.id}`);

    card.innerHTML = `
     @if (Model != null && Model.Email == "admin@bnc.com")
                    {
     <div id="${item.id}" class="card-item">
        <div class="editor">
          <a href="#" onclick="postEdit('card${item.id}')">
            <img src="images/edit.png" alt="Botão" />
          </a>
        </div>
        }
        <img class="img-card" src="${item.imagem}" alt="${item.nome}" />
        <div class="card-content">
          <h3>${item.nome}</h3>
          <p>${item.descricao}</p>
        </div>
        <button type="button">Comprar</button>
     </div>
     
    `;

    cardWrapper.appendChild(card);
}
function saveNewPost() {
    const title = document.getElementById('postTitle').value;
    const description = document.getElementById('postDescription').value;
    const image = document.getElementById('postImage').value;

    if (title && description && image) {

        const newItem = {
            id: itens.length + 1,
            nome: title,
            descricao: description,
            imagem: image
        };

        itens.push(newItem);

        renderItem(newItem);

        closeAddPostModal();

        document.getElementById('addPostForm').reset();
    } else {
        alert('Por favor, preencha todos os campos.');
    }
}

function postEdit(cardID) {
    const cardIndex = itens.findIndex(item => `card${item.id}` === cardID);
    const item = itens[cardIndex];

    const action = prompt('Escolha uma ação: "editar" ou "deletar"').toLowerCase();

    if (action === 'editar') {
        const newTitle = prompt('Edite o nome do console:', item.nome);
        const newDescription = prompt('Edite a descrição:', item.descricao);
        const newImage = prompt('Edite o caminho da imagem:', item.imagem);


        if (newTitle) item.nome = newTitle;
        if (newDescription) item.descricao = newDescription;
        if (newImage) item.imagem = newImage;

        const card = document.getElementById(cardID);
        card.querySelector('.card-content h3').textContent = item.nome;
        card.querySelector('.card-content p').textContent = item.descricao;
        const mainImage = card.querySelector('.img-card');
        mainImage.src = item.imagem;
        mainImage.alt = item.nome;



    } else if (action === 'deletar') {
        const confirmDelete = confirm('Tem certeza que deseja deletar este card?');
        if (confirmDelete) {
            itens.splice(cardIndex, 1);
            document.getElementById(cardID).remove();
        }
    } else {
        alert('Ação inválida. Escolha "editar" ou "deletar".');
    }
}


function filterCatalog() {
    const searchInput = document.getElementById('searchInput').value.toLowerCase();
    const cardItems = document.querySelectorAll('.card-item');

    cardItems.forEach(item => {
        const title = item.querySelector('h3').textContent.toLowerCase();
        if (title.includes(searchInput)) {
            item.style.visibility = 'visible'; 
            item.style.position = 'relative';
        } else {
            item.style.visibility = 'hidden'; 
            item.style.position = 'absolute';
        }
    });
}


function adicionarPost() {
    document.getElementById('addPostModal').style.display = 'flex';
}

function closeAddPostModal() {
    document.getElementById('addPostModal').style.display = 'none';
}

function containsNumbers(str) {
    return /\d/.test(str);
}

function validatePostalCode(postalCode) {
    return /^\d{5}-\d{3}$/.test(postalCode);
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email) && email.endsWith(".com");
}

function validateRegisterForm() {
    let isValid = true;

    const firstName = document.getElementById('firstName');
    
    const gender = document.getElementById('validationCustom04');
    const username = document.getElementById('validationCustomUsername');
    const email = document.getElementById('email');
    const postalCode = document.getElementById('postalCode');
    const password = document.getElementById('password');
    const checkbox = document.getElementById('invalidCheck');

    if (firstName.value.length < 2 || containsNumbers(firstName.value)) {
        firstName.classList.add('is-invalid');
        isValid = false;
    } else {
        firstName.classList.remove('is-invalid');
        firstName.classList.add('is-valid');
    }
    if (gender.value === "") {
        gender.classList.add('is-invalid');
        isValid = false;
    } else {
        gender.classList.remove('is-invalid');
        gender.classList.add('is-valid');
    }

    if (username.value.trim() === "") {
        username.classList.add('is-invalid');
        isValid = false;
    } else {
        username.classList.remove('is-invalid');
        username.classList.add('is-valid');
    }

    if (!validateEmail(email.value)) {
        email.classList.add('is-invalid');
        isValid = false;
    } else {
        email.classList.remove('is-invalid');
        email.classList.add('is-valid');
    }

    if (!validatePostalCode(postalCode.value)) {
        postalCode.classList.add('is-invalid');
        isValid = false;
    } else {
        postalCode.classList.remove('is-invalid');
        postalCode.classList.add('is-valid');
    }

    if (password.value.length < 4) {
        password.classList.add('is-invalid');
        isValid = false;
    } else {
        password.classList.remove('is-invalid');
        password.classList.add('is-valid');
    }

    if (!checkbox.checked) {
        checkbox.classList.add('is-invalid');
        isValid = false;
    } else {
        checkbox.classList.remove('is-invalid');
        checkbox.classList.add('is-valid');
    }

    if (isValid) {
        document.getElementById('registerForm').submit();
    }
}

function validateEmail(email) {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email) && email.endsWith(".com");
}

function validateLoginForm(event) {
    let isValid = true;

    const email = document.getElementById('email');
    const password = document.getElementById('password');
    const emailError = document.getElementById('emailError');
    const passwordError = document.getElementById('passwordError');

    
    if (!validateEmail(email.value)) {
        email.classList.add('is-invalid');
        emailError.style.display = 'block';
        isValid = false;
    } else {
        email.classList.remove('is-invalid');
        emailError.style.display = 'none';
    }


    if (password.value.length < 4) {
        password.classList.add('is-invalid');
        passwordError.style.display = 'block';
        isValid = false;
    } else {
        password.classList.remove('is-invalid');
        passwordError.style.display = 'none';
    }

    
    if (!isValid) {
        event.preventDefault();
    }
}