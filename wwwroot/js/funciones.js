document.addEventListener("DOMContentLoaded", function () {
    const select = document.getElementById("opciones");
    const inputTexto = document.getElementById("textbuscar");
    select.addEventListener("change", function () {
        if (select.value == "0") {
            inputTexto.hidden = true;
        } else if (select.value == "1") {
            inputTexto.hidden = false;
            inputTexto.placeholder = "Ingrese el coctel";
        } else {
            inputTexto.hidden = false;
            inputTexto.placeholder = "Ingrese el ingrediente";
        }
    });

});

function openModal() {
    var table = document.getElementById('example');

    table.addEventListener('click', function (event) {
        var target = event.target;
        if (target.id === 'cuerpobtn') {
            var row = target.parentNode;
            var rowIndex = row.rowIndex;
            var id = target.parentNode.cells[0].textContent;
            //alert('Fila clickeada: ' + rowIndex);
            $.ajax({
                url: '/Home/ObtieneDetalle',
                type: 'POST',
                data: { valor: id },
                success: function (response) {
                    const modal = document.createElement("div");
                    modal.id = "modal";
                    modal.className = "modal";

                    const modalContent = document.createElement("div");
                    modalContent.className = "modal-content";

                    const closeBtn = document.createElement("span");
                    closeBtn.className = "close";
                    closeBtn.innerHTML = "&times;";
                    closeBtn.addEventListener("click", closeModal);

                    const img = document.createElement("img");
                    img.src = response.foto; // Reemplaza con la ruta de tu imagen
                    img.alt = "Imagen";

                    const text = document.createElement("p");
                    text.textContent ="Categoria: "+ response.categoria;

                    modalContent.appendChild(closeBtn);
                    modalContent.appendChild(img);
                    modalContent.appendChild(text);
                    modal.appendChild(modalContent);

                    document.body.appendChild(modal);

                    modal.style.display = "block";
                },
                error: function (error) {
                    // Manejar errores aquí
                    console.log(error);
                }
            });
        }
    });
    
}

function closeModal() {
    const modal = document.getElementById("modal");
    if (modal) {
        document.body.removeChild(modal);
    }
}

const modalBtn = document.getElementById("modalBtn");
modalBtn.addEventListener("click", openModal);


function saveToLocalStorage() {
    try {
        var key = "cocteles"
        var table = document.getElementById('example');

        table.addEventListener('click', function (event) {
            var target = event.target;
            if (target.id === 'cuerpobtn2') {
                var row = target.parentNode;
                var rowIndex = row.rowIndex;
                var id = target.parentNode.cells[0].textContent;
                var nam = target.parentNode.cells[1].textContent;
                const coctel = {
                    id: id,
                    name: nam
                };
                const existingCoctelesJSON = localStorage.getItem(key);
                const existingCocteles = existingCoctelesJSON ? JSON.parse(existingCoctelesJSON) : [];

                // Agregar el nuevo coctel al array
                existingCocteles.push(coctel);

                // Guardar el array actualizado en el almacenamiento local
                const updatedCoctelesJSON = JSON.stringify(existingCocteles);
                localStorage.setItem(key, updatedCoctelesJSON);
                alert("Coctel agregado a favoritos")
                console.log(`Objeto guardado en localStorage con la clave: ${key}`);
            }
        });
    } catch (error) {
        console.error(`Error al guardar en localStorage: ${error}`);
    }
}

function getFromLocalStorage(key) {
    try {
        const valueJSON = localStorage.getItem(key);
        return JSON.parse(valueJSON);
    } catch (error) {
        console.error(`Error al obtener datos de localStorage: ${error}`);
        return null;
    }
}
function favo() {

    const savedCocteles = getFromLocalStorage("cocteles");

        // Mostrar los datos en la vista HTML
    const favoritosTable = document.getElementById("favoritos-table");
    favoritosTable.innerHTML = '';
    if (savedCocteles) {
        savedCocteles.forEach(coctel => {
            const newRow = favoritosTable.insertRow();

            //const idCell = newRow.insertCell();
            const nameCell = newRow.insertCell();
            const removeCell = newRow.insertCell();

            //idCell.textContent = coctel.id;
            nameCell.textContent = coctel.name;

            const removeButton = document.createElement("button");
            removeButton.textContent = "Eliminar";
            removeButton.addEventListener("click", function () {
                removeFromLocalStorage("cocteles", coctel.id);
                favo(); // Actualizar la tabla después de eliminar
            });

            removeCell.appendChild(removeButton);
        });
    } else {
        const newRow = favoritosTable.insertRow();
        const noDataCell = newRow.insertCell();

        noDataCell.colSpan = 3; // Ajustar al número de columnas en la tabla
        noDataCell.textContent = "No hay cocteles guardados.";
    }

}
function removeFromLocalStorage(key, idToRemove) {
    try {
        const existingCoctelesJSON = localStorage.getItem(key);
        const existingCocteles = existingCoctelesJSON ? JSON.parse(existingCoctelesJSON) : [];

        // Filtrar el array para eliminar el coctel con el ID especificado
        const updatedCocteles = existingCocteles.filter(coctel => coctel.id !== idToRemove);

        // Guardar el array actualizado en el almacenamiento local
        const updatedCoctelesJSON = JSON.stringify(updatedCocteles);
        localStorage.setItem(key, updatedCoctelesJSON);

        console.log(`Elemento con ID ${idToRemove} removido de localStorage con la clave: ${key}`);
    } catch (error) {
        console.error(`Error al remover elemento de localStorage: ${error}`);
    }
}

