import {stores, pos} from './data/index.js';

let viewMode=true;  //table mode
let newItem=false;  //add new stock mode

const fillPos=(pos)=>{
    const table=document.querySelector('.table-container');
    const card=document.querySelector('.cards-container');
    if(viewMode){
        clearTable();
        pos.forEach(element => {
            table.classList.remove('hidden');
            card.classList.add('hidden');
            card.classList.remove('columns');
            addPosToTable(element);
        })
    }else{
        clearCards();
        pos.forEach(element => {
            table.classList.add('hidden');
            card.classList.remove('hidden');
            card.classList.add('columns');
            addPosToCard(element);
        })
    }
}

const addPosToTable=(pos)=>{
    const row=document.createElement('tr');
    row.classList.add('data-row');
    const idCell=document.createElement('td');
    idCell.classList.add('id-cell');
    idCell.innerText=pos.id;
    row.appendChild(idCell);
    const storeCell=document.createElement('td');
    storeCell.classList.add('store-cell');
    storeCell.innerText=pos.store;
    row.appendChild(storeCell);
    const addressCell=document.createElement('td');
    addressCell.classList.add('address-cell');
    addressCell.innerText=pos.address;
    row.appendChild(addressCell);
    const editCell=document.createElement('td');
    const editButton=document.createElement('div');
    editButton.classList.add('edit-button');
    editButton.classList.add('table-button-1');
    editCell.appendChild(editButton);
    editButton.addEventListener('click', editPosInTable);
    row.appendChild(editCell);
    const deleteCell=document.createElement('td');
    const deleteButton=document.createElement('button');
    deleteButton.classList.add('delete');
    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', removePosFromTable);
    row.appendChild(deleteCell);
    const content=document.querySelector('.table__content');
    const form=document.querySelector('.table__form');
    content.insertBefore(row, form);
}

const addPosToCard=(pos)=>{
    const container=document.querySelector('.cards-container');
    const cardTempl=document.querySelector('.card-container');
    const card=document.createElement('div');
    card.classList.add('card-container');
    card.classList.add('column');
    card.classList.add('is-half');
    card.classList.add('data-card');
    card.innerHTML=cardTempl.innerHTML;
    const col1=card.querySelector('.content__data__column-1');
    const col2=card.querySelector('.content__data__column-2');
    const idKeyDiv=document.createElement('div');
    idKeyDiv.classList.add('id-key');
    idKeyDiv.innerText='Id';
    const idValDiv=document.createElement('div');
    idValDiv.classList.add('id-val');
    idValDiv.innerText=pos.id===undefined?'':pos.id;
    col1.appendChild(idKeyDiv);
    col2.appendChild(idValDiv);
    const storeKeyDiv=document.createElement('div');
    storeKeyDiv.classList.add('store-key');
    storeKeyDiv.innerText='Store';
    const storeValDiv=document.createElement('div');
    storeValDiv.classList.add('store-val');
    storeValDiv.innerText=pos.store===undefined?'':pos.store;
    col1.appendChild(storeKeyDiv);
    col2.appendChild(storeValDiv);
    const addressKeyDiv=document.createElement('div');
    addressKeyDiv.classList.add('address-key');
    addressKeyDiv.innerText='Address';
    const addressValDiv=document.createElement('div');
    addressValDiv.classList.add('address-val');
    addressValDiv.innerText=pos.address===undefined?'':pos.address;
    col1.appendChild(addressKeyDiv);
    col2.appendChild(addressValDiv);
    const deleteButton=card.querySelector('.card__button-2');
    deleteButton.addEventListener('click', removePosCard);
    const editButton=card.querySelector('.card__button-1');
    editButton.addEventListener('click', editPosCard);
    container.appendChild(card);
}

const submitPos=()=>{
    const idInput=document.querySelector('.id-input');
    const storeSelect=document.querySelector('.store-select');
    const addressSelect=document.querySelector('.address-select');
    const pos={};
    pos.id=idInput.value;
    pos.store=storeSelect.value;
    pos.address=addressSelect.value;
    addPosToTable(pos);
}

const removePosFromTable=(e)=>{
    const pos=e.target.parentNode.parentNode;
    pos.remove();
}

const clearTable=()=>{
    const dataRows=document.querySelectorAll('.data-row');
    dataRows.forEach(element => {
        element.remove();
    });
}

const removePosCard=(e)=>{
    const card=e.target.parentNode.parentNode.parentNode;
    card.remove();
}

const clearCards=()=>{
    const dataCards=document.querySelectorAll('.data-card');
    dataCards.forEach(element => {
        element.remove();
    });
}

const editPosInTable=(e)=>{
    const pos=e.target.parentNode.parentNode;
    pos.classList.add('table__form');
    const idCell=pos.querySelector('.id-cell');
    const storeCell=pos.querySelector('.store-cell');
    const addressCell=pos.querySelector('.address-cell');
    const editButton=pos.querySelector('.table-button-1');
    editButton.classList.replace('edit-button', 'submit-button');
    editButton.removeEventListener('click', editPosInTable);
    editButton.addEventListener('click', validateForm);
    const idInput=document.createElement('input');
    const idAtr = document.createAttribute("name");      
    idAtr.value = "id";                           
    idInput.setAttributeNode(idAtr);
    const reqIdAtr = document.createAttribute("required");
    idInput.setAttributeNode(reqIdAtr);
    idInput.classList.add('id-input');
    idInput.classList.add('input');
    idInput.value=idCell.innerText;
    idCell.innerText='';
    idCell.appendChild(idInput);
    const storeContainer=document.createElement('span');
    storeContainer.classList.add('select');
    const storeSelect=document.createElement('select');
    storeSelect.classList.add('store-select');
    storeSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.name;
        storeSelect.appendChild(option);
    });
    storeSelect.value=storeCell.innerText;
    storeCell.innerText='';
    storeContainer.appendChild(storeSelect);
    storeCell.appendChild(storeContainer);
    const addressContainer=document.createElement('span');
    addressContainer.classList.add('select');
    const addressSelect=document.createElement('select');
    addressSelect.classList.add('address-select');
    addressSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.address;
        addressSelect.appendChild(option);
    });
    addressSelect.value=addressCell.innerText;
    addressCell.innerText='';
    addressContainer.appendChild(addressSelect);
    addressCell.appendChild(addressContainer);
    const inputList=product.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const editPosCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.add('card-form');
    const idDiv=card.querySelector('.id-val');
    const storeDiv=card.querySelector('.store-val');
    const addressDiv=card.querySelector('.address-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__edit-button', 'card__save-button');
    editButton.removeEventListener('click', editPosCard);
    editButton.addEventListener('click', validateForm);
    const idInput=document.createElement('input');
    const idAtr = document.createAttribute("name");      
    idAtr.value = "id";                           
    idInput.setAttributeNode(idAtr);
    const reqIdAtr = document.createAttribute("required");
    idInput.setAttributeNode(reqIdAtr);
    idInput.classList.add('id-input');
    idInput.classList.add('input');
    idInput.placeholder='id';
    idInput.value=idDiv.innerText;
    idDiv.innerText='';
    idDiv.appendChild(idInput);
    const storeSelect=document.createElement('select');
    storeSelect.classList.add('store-select');
    storeSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.name;
        storeSelect.appendChild(option);
    });
    if(storeDiv.innerText!=='')
    {
        storeSelect.value=storeDiv.innerText;
        storeDiv.innerText='';
    }else{
        storeSelect.options.selectedIndex=0;
    }
    storeDiv.appendChild(storeSelect);
    const addressSelect=document.createElement('select');
    addressSelect.classList.add('address-select');
    addressSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.address;
        addressSelect.appendChild(option);
    });
    if(addressDiv.innerText!=='')
    {
        addressSelect.value=addressDiv.innerText;
        addressDiv.innerText='';
    }else{
        addressSelect.options.selectedIndex=0;
    }
    addressDiv.appendChild(addressSelect);
    const inputList=card.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const savePosCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.remove('card-form');
    const idDiv=card.querySelector('.id-val');
    const storeDiv=card.querySelector('.store-val');
    const addressDiv=card.querySelector('.address-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__save-button', 'card__edit-button');
    editButton.removeEventListener('click', validateForm);
    editButton.addEventListener('click', editPosCard);
    const idInput=card.querySelector('.id-input');
    const storeSelect=card.querySelector('.store-select');
    const addressSelect=card.querySelector('.address-select');
    const pos={};
    pos.id=idInput.value;
    pos.store=storeSelect.value;
    pos.address=addressSelect.value;
    idDiv.innerText=pos.id;
    storeDiv.innerText=pos.store;
    addressDiv.innerText=pos.address;
}

//  fill table with data
fillPos(pos);

//  add view-mode event listener
const tableModeButton=document.querySelector('.view-options__table');
tableModeButton.addEventListener('click', ()=>{
    if(!viewMode)
    {
        viewMode=true;
        fillPos(pos);
    }
})
const cardModeButton=document.querySelector('.view-options__card');
cardModeButton.addEventListener('click', ()=>{
    if(viewMode)
    {
        viewMode=false;
        fillPos(pos);
    }
})


//  Validate input method
const validateInput=(e)=>{
    const el=e.target;
    const name=el.name;
    let err=document.querySelector('.'+name+'__error');
        if(!el.checkValidity()){
            if(!err)
            {
                //input error message
                err=document.createElement('div');
                err.classList.add(name+'__error');
                err.classList.add('error-message');
                err.innerHTML='Field "'+name+'": '+el.validationMessage;
                const container=document.querySelector('.error-container');
                container.appendChild(err);
                el.classList.add('error');
            }else{
                err.innerHTML='Field "'+name+'": '+el.validationMessage;
            }
        }else{
            if(err){
                err.remove();
            }
            el.classList.remove('error');
        }
};

//  validate form method
const validateForm=(e)=>{
    const formRow=e.target.parentNode.parentNode;
    const inputList=formRow.querySelectorAll('.input');
    for(let i=0; i<inputList.length; ++i) {
        if(!inputList[i].checkValidity()){
            const name=inputList[i].name;
            let err=document.querySelector('.'+name+'__error');
            if(!err)
            {
                //input error message
                err=document.createElement('div');
                err.classList.add(name+'__error');
                err.classList.add('error-message');
                err.innerHTML='Field "'+name+'": '+inputList[i].validationMessage;
                let container=document.querySelector('.error-container');
                container.appendChild(err);
                inputList[i].classList.add('error');
            }else{
                err.innerHTML='Field "'+name+'": '+inputList[i].validationMessage;
            }
            return;
        }
    };
    if(viewMode){
        submitPos();
        if(newItem){
            const form=document.querySelector('form');
            form.reset();
            addButton.click();
            newItem=false;
        }else{
            formRow.remove();
        }
    }else{
        savePosCard(e);
    }
}

//  add pos event listener
const addButton=document.querySelector('.add-pos-button');
const form=document.querySelector('.table__form');
addButton.addEventListener('click', function(){
    if(viewMode)
    {
        form.classList.toggle('hidden');
        this.classList.toggle('hide-button');
        this.classList.toggle('add-pos-button');
        const inputList=form.querySelectorAll('.input');
        inputList.forEach(element => {
            element.addEventListener('blur', validateInput);
        });
        const storeSelect=document.querySelector('.store-select');
        stores.forEach(store => {
            const option=document.createElement('option');
            option.innerText=store.name;
            storeSelect.appendChild(option);
        });
        const addressSelect=document.querySelector('.address-select');
        stores.forEach(store => {
            const option=document.createElement('option');
            option.innerText=store.address;
            addressSelect.appendChild(option);
        });
        newItem=true;
    }else{
        const emptyPos={ };
        addPosToCard(emptyPos);
        const lastCard=document.querySelector('.cards-container').lastChild;
        const editButton=lastCard.querySelector('.card__button-1');
        editButton.click();
    }
});

//  submit new product form event listener
const submitButton=document.querySelector('.submit-button');
submitButton.addEventListener('click', validateForm);