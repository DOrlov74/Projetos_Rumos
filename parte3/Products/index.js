import {products, families} from '../data/index.js';

let viewMode=true;  //table mode
let newItem=false;  //add new product mode

const fillProducts=(products)=>{
    const table=document.querySelector('.table-container');
    const card=document.querySelector('.cards-container');
    if(viewMode){
        clearTable();
        products.forEach(element => {
            table.classList.remove('hidden');
            card.classList.add('hidden');
            card.classList.remove('columns');
            addProductToTable(element);
        })
    }else{
        clearCards();
        products.forEach(element => {
            table.classList.add('hidden');
            card.classList.remove('hidden');
            card.classList.add('columns');
            addProductToCard(element);
        })
    }
}

const addProductToTable=(product)=>{
    const row=document.createElement('tr');
    row.classList.add('data-row');
    const idCell=document.createElement('td');
    idCell.classList.add('id-cell');
    idCell.innerText=product.id;
    row.appendChild(idCell);
    const nameCell=document.createElement('td');
    nameCell.classList.add('name-cell');
    nameCell.innerText=product.productName;
    row.appendChild(nameCell);
    const barcodeCell=document.createElement('td');
    barcodeCell.classList.add('barcode-cell');
    barcodeCell.innerText=product.barcode;
    row.appendChild(barcodeCell);
    const familyCell=document.createElement('td');
    familyCell.classList.add('family-cell');
    familyCell.innerText=product.family;
    row.appendChild(familyCell);
    const measureCell=document.createElement('td');
    measureCell.classList.add('measure-cell');
    measureCell.innerText=product.unitMeasure;
    row.appendChild(measureCell);
    const quantityCell=document.createElement('td');
    quantityCell.classList.add('quantity-cell');
    quantityCell.innerText=product.qtyPerUnit;
    row.appendChild(quantityCell);
    const priceCell=document.createElement('td');
    priceCell.classList.add('price-cell');
    priceCell.innerText=product.unitPrice;
    row.appendChild(priceCell);
    const discontinuedCell=document.createElement('td');
    discontinuedCell.classList.add('discontinued-cell');
    discontinuedCell.innerText=product.discontinued;
    row.appendChild(discontinuedCell);
    const createdCell=document.createElement('td');
    createdCell.classList.add('created-cell');
    createdCell.innerText=product.dateCreated;
    row.appendChild(createdCell);
    const modifiedCell=document.createElement('td');
    modifiedCell.classList.add('modified-cell');
    modifiedCell.innerText=product.dateModified;
    row.appendChild(modifiedCell);
    const editCell=document.createElement('td');
    const editButton=document.createElement('div');
    editButton.classList.add('edit-button');
    editButton.classList.add('table-button-1');
    editCell.appendChild(editButton);
    editButton.addEventListener('click', editProductInTable);
    row.appendChild(editCell);
    const deleteCell=document.createElement('td');
    const deleteButton=document.createElement('button');
    deleteButton.classList.add('delete');
    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', removeProductFromTable);
    row.appendChild(deleteCell);
    const content=document.querySelector('.table__content');
    const form=document.querySelector('.table__form');
    content.insertBefore(row, form);
}

const addProductToCard=(product)=>{
    const container=document.querySelector('.cards-container');
    const cardTempl=document.querySelector('.card-container');
    const card=document.createElement('div');
    card.classList.add('card-container');
    card.classList.add('column');
    card.classList.add('is-one-third');
    card.classList.add('data-card');
    card.innerHTML=cardTempl.innerHTML;
    const col1=card.querySelector('.content__data__column-1');
    const col2=card.querySelector('.content__data__column-2');
    const idKeyDiv=document.createElement('div');
    idKeyDiv.classList.add('id-key');
    idKeyDiv.innerText='Id';
    const idValDiv=document.createElement('div');
    idValDiv.classList.add('id-val');
    idValDiv.innerText=product.id===undefined?'':product.id;
    col1.appendChild(idKeyDiv);
    col2.appendChild(idValDiv);
    const nameKeyDiv=document.createElement('div');
    nameKeyDiv.classList.add('name-key');
    nameKeyDiv.innerText='Product Name';
    const nameValDiv=document.createElement('div');
    nameValDiv.classList.add('name-val');
    nameValDiv.innerText=product.productName===undefined?'':product.productName;
    col1.appendChild(nameKeyDiv);
    col2.appendChild(nameValDiv);
    const barcodeKeyDiv=document.createElement('div');
    barcodeKeyDiv.classList.add('barcode-key');
    barcodeKeyDiv.innerText='Barcode';
    const barcodeValDiv=document.createElement('div');
    barcodeValDiv.classList.add('barcode-val');
    barcodeValDiv.innerText=product.barcode===undefined?'':product.barcode;
    col1.appendChild(barcodeKeyDiv);
    col2.appendChild(barcodeValDiv);
    const familyKeyDiv=document.createElement('div');
    familyKeyDiv.classList.add('family-key');
    familyKeyDiv.innerText='Family';
    const familyValDiv=document.createElement('div');
    familyValDiv.classList.add('family-val');
    familyValDiv.innerText=product.family===undefined?'':product.family;
    col1.appendChild(familyKeyDiv);
    col2.appendChild(familyValDiv);
    const measureKeyDiv=document.createElement('div');
    measureKeyDiv.classList.add('measure-key');
    measureKeyDiv.innerText='Unit Measure';
    const measureValDiv=document.createElement('div');
    measureValDiv.classList.add('measure-val');
    measureValDiv.innerText=product.unitMeasure===undefined?'':product.unitMeasure;
    col1.appendChild(measureKeyDiv);
    col2.appendChild(measureValDiv);
    const quantityKeyDiv=document.createElement('div');
    quantityKeyDiv.classList.add('quantity-key');
    quantityKeyDiv.innerText='Quantity per Unit';
    const quantityValDiv=document.createElement('div');
    quantityValDiv.classList.add('quantity-val');
    quantityValDiv.innerText=product.qtyPerUnit===undefined?'':product.qtyPerUnit;
    col1.appendChild(quantityKeyDiv);
    col2.appendChild(quantityValDiv);
    const priceKeyDiv=document.createElement('div');
    priceKeyDiv.classList.add('price-key');
    priceKeyDiv.innerText='Unit Price';
    const priceValDiv=document.createElement('div');
    priceValDiv.classList.add('price-val');
    priceValDiv.innerText=product.unitPrice===undefined?'':product.unitPrice;
    col1.appendChild(priceKeyDiv);
    col2.appendChild(priceValDiv);
    const discontinuedKeyDiv=document.createElement('div');
    discontinuedKeyDiv.classList.add('discontinued-key');
    discontinuedKeyDiv.innerText='Discontinued';
    const discontinuedValDiv=document.createElement('div');
    discontinuedValDiv.classList.add('discontinued-val');
    discontinuedValDiv.innerText=product.discontinued===undefined?true:product.discontinued;
    col1.appendChild(discontinuedKeyDiv);
    col2.appendChild(discontinuedValDiv);
    const createdKeyDiv=document.createElement('div');
    createdKeyDiv.classList.add('created-key');
    createdKeyDiv.innerText='Created at';
    const createdValDiv=document.createElement('div');
    createdValDiv.classList.add('created-val');
    createdValDiv.innerText=product.dateCreated===undefined?date:product.dateCreated;
    col1.appendChild(createdKeyDiv);
    col2.appendChild(createdValDiv);
    const modifiedKeyDiv=document.createElement('div');
    modifiedKeyDiv.classList.add('modified-key');
    modifiedKeyDiv.innerText='Modified at';
    const modifiedValDiv=document.createElement('div');
    modifiedValDiv.classList.add('modified-val');
    modifiedValDiv.innerText=product.dateModified===undefined?date:product.dateModified;
    col1.appendChild(modifiedKeyDiv);
    col2.appendChild(modifiedValDiv);
    /* Object.entries(product).map(([key, value]) =>{
        const name=document.createElement('div');
        name.classList.add(key);
        const val=document.createElement('div');
        val.classList.add(key+'val');
        name.innerText=key;
        val.innerText=value;
        col1.appendChild(name);
        col2.appendChild(val);
    }); */
    const deleteButton=card.querySelector('.card__button-2');
    deleteButton.addEventListener('click', removeProductCard);
    const editButton=card.querySelector('.card__button-1');
    editButton.addEventListener('click', editProductCard);
    container.appendChild(card);
}

const submitProduct=()=>{
    const idInput=document.querySelector('.id-input');
    const nameInput=document.querySelector('.product-name-input');
    const barcodeInput=document.querySelector('.barcode-input');
    const familySelect=document.querySelector('.family-select');
    const measureInput=document.querySelector('.unit-measure-input');
    const qtyInput=document.querySelector('.qty-per-unit-input');
    const priceInput=document.querySelector('.unit-price-input');
    const discontinuedSelect=document.querySelector('.discontinued-select');
    const createdInput=document.querySelector('.created-at-input');
    const modifiedInput=document.querySelector('.modified-at-input');
    const product={};
    product.id=idInput.value;
    product.productName=nameInput.value;
    product.barcode=barcodeInput.value;
    product.family=familySelect.value;
    product.unitMeasure=measureInput.value;
    product.qtyPerUnit=qtyInput.value;
    product.unitPrice=priceInput.value;
    product.discontinued=discontinuedSelect.value;
    product.dateCreated=createdInput.value;
    product.dateModified=modifiedInput.value;
    addProductToTable(product);
}

const removeProductFromTable=(e)=>{
    const product=e.target.parentNode.parentNode;
    product.remove();
}

const clearTable=()=>{
    const dataRows=document.querySelectorAll('.data-row');
    dataRows.forEach(element => {
        element.remove();
    });
}

const removeProductCard=(e)=>{
    const card=e.target.parentNode.parentNode.parentNode;
    card.remove();
}

const clearCards=()=>{
    const dataCards=document.querySelectorAll('.data-card');
    dataCards.forEach(element => {
        element.remove();
    });
}

const editProductInTable=(e)=>{
    const product=e.target.parentNode.parentNode;
    product.classList.add('table__form');
    const idCell=product.querySelector('.id-cell');
    const nameCell=product.querySelector('.name-cell');
    const barcodeCell=product.querySelector('.barcode-cell');
    const familyCell=product.querySelector('.family-cell');
    const measureCell=product.querySelector('.measure-cell');
    const qtyCell=product.querySelector('.quantity-cell');
    const priceCell=product.querySelector('.price-cell');
    const discontinuedCell=product.querySelector('.discontinued-cell');
    const createdCell=product.querySelector('.created-cell');
    const modifiedCell=product.querySelector('.modified-cell');
    const editButton=product.querySelector('.table-button-1');
    editButton.classList.replace('edit-button', 'submit-button');
    editButton.removeEventListener('click', editProductInTable);
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
    const nameInput=document.createElement('input');
    const nameAtr = document.createAttribute("name");      
    nameAtr.value = "product-name";                           
    nameInput.setAttributeNode(nameAtr);
    const reqNameAtr = document.createAttribute("required");
    nameInput.setAttributeNode(reqNameAtr);
    nameInput.classList.add('product-name-input');
    nameInput.classList.add('input');
    nameInput.value=nameCell.innerText;
    nameCell.innerText='';
    nameCell.appendChild(nameInput);
    const barcodeInput=document.createElement('input');
    const barcodeAtr = document.createAttribute("name");      
    barcodeAtr.value = "barcode";                           
    barcodeInput.setAttributeNode(barcodeAtr);
    barcodeInput.classList.add('barcode-input');
    barcodeInput.classList.add('input');
    barcodeInput.value=barcodeCell.innerText;
    barcodeCell.innerText='';
    barcodeCell.appendChild(barcodeInput);
    const familyContainer=document.createElement('span');
    familyContainer.classList.add('select');
    const familySelect=document.createElement('select');
    familySelect.classList.add('family-select');
    familySelect.classList.add('select');
    families.forEach(family => {
        const option=document.createElement('option');
        option.innerText=family.name;
        familySelect.appendChild(option);
    });
    familySelect.value=familyCell.innerText;
    familyCell.innerText='';
    familyContainer.appendChild(familySelect);
    familyCell.appendChild(familyContainer);
    const measureInput=document.createElement('input');
    const measureAtr = document.createAttribute("name");      
    measureAtr.value = "unit-measure";                           
    measureInput.setAttributeNode(measureAtr);
    measureInput.classList.add('unit-measure-input');
    measureInput.classList.add('input');
    measureInput.value=measureCell.innerText;
    measureCell.innerText='';
    measureCell.appendChild(measureInput);
    const qtyInput=document.createElement('input');
    const qtyAtr = document.createAttribute("name");      
    qtyAtr.value = "quantity-per-unit";                           
    qtyInput.setAttributeNode(qtyAtr);
    qtyInput.classList.add('qty-per-unit-input');
    qtyInput.classList.add('input');
    qtyInput.value=qtyCell.innerText;
    qtyCell.innerText='';
    qtyCell.appendChild(qtyInput);
    const priceInput=document.createElement('input');
    const priceAtr = document.createAttribute("name");      
    priceAtr.value = "unit-price";                           
    priceInput.setAttributeNode(priceAtr);
    priceInput.classList.add('unit-price-input');
    priceInput.classList.add('input');
    priceInput.value=priceCell.innerText;
    priceCell.innerText='';
    priceCell.appendChild(priceInput);
    const discontinuedContainer=document.createElement('span');
    discontinuedContainer.classList.add('select');
    const discontinuedSelect=document.createElement('select');
    discontinuedSelect.classList.add('discontinued-select');
    discontinuedSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    discontinuedSelect.appendChild(trueOption);
    discontinuedSelect.appendChild(falseOption);
    discontinuedSelect.value=discontinuedCell.innerText;
    discontinuedCell.innerText='';
    discontinuedContainer.appendChild(discontinuedSelect);
    discontinuedCell.appendChild(discontinuedContainer);
    const createdInput=document.createElement('input');
    const createdAtr = document.createAttribute("name");      
    createdAtr.value = "created-at";                           
    createdInput.setAttributeNode(createdAtr);
    createdInput.classList.add('created-at-input');
    createdInput.classList.add('input');
    createdInput.value=createdCell.innerText;
    createdCell.innerText='';
    createdCell.appendChild(createdInput);
    const modifiedInput=document.createElement('input');
    const modifiedAtr = document.createAttribute("name");      
    modifiedAtr.value = "modified-at";                           
    modifiedInput.setAttributeNode(modifiedAtr);
    modifiedInput.classList.add('modified-at-input');
    modifiedInput.classList.add('input');
    modifiedInput.value=date;
    modifiedCell.innerText='';
    modifiedCell.appendChild(modifiedInput);
    const inputList=product.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const editProductCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.add('card-form');
    const idDiv=card.querySelector('.id-val');
    const nameDiv=card.querySelector('.name-val');
    const barcodeDiv=card.querySelector('.barcode-val');
    const familyDiv=card.querySelector('.family-val');
    const measureDiv=card.querySelector('.measure-val');
    const qtyDiv=card.querySelector('.quantity-val');
    const priceDiv=card.querySelector('.price-val');
    const discontinuedDiv=card.querySelector('.discontinued-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__edit-button', 'card__save-button');
    editButton.removeEventListener('click', editProductCard);
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
    const nameInput=document.createElement('input');
    const nameAtr = document.createAttribute("name");      
    nameAtr.value = "product-name";                           
    nameInput.setAttributeNode(nameAtr);
    const reqNameAtr = document.createAttribute("required");
    nameInput.setAttributeNode(reqNameAtr);
    nameInput.classList.add('product-name-input');
    nameInput.classList.add('input');
    nameInput.placeholder='Product Name';
    nameInput.value=nameDiv.innerText;
    nameDiv.innerText='';
    nameDiv.appendChild(nameInput);
    const barcodeInput=document.createElement('input');
    const barcodeAtr = document.createAttribute("name");      
    barcodeAtr.value = "barcode";                           
    barcodeInput.setAttributeNode(barcodeAtr);
    barcodeInput.classList.add('barcode-input');
    barcodeInput.classList.add('input');
    barcodeInput.placeholder='barcode';
    barcodeInput.value=barcodeDiv.innerText;
    barcodeDiv.innerText='';
    barcodeDiv.appendChild(barcodeInput);
    const familySelect=document.createElement('select');
    familySelect.classList.add('family-select');
    familySelect.classList.add('select');
    families.forEach(family => {
        const option=document.createElement('option');
        option.innerText=family.name;
        familySelect.appendChild(option);
    });
    if(familyDiv.innerText!=='')
    {
        familySelect.value=familyDiv.innerText;
        familyDiv.innerText='';
    }else{
        familySelect.options.selectedIndex=0;
    }
    familyDiv.appendChild(familySelect);
    const measureInput=document.createElement('input');
    const measureAtr = document.createAttribute("name");      
    measureAtr.value = "unit-measure";                           
    measureInput.setAttributeNode(measureAtr);
    measureInput.classList.add('unit-measure-input');
    measureInput.classList.add('input');
    measureInput.placeholder='Unit Measure';
    measureInput.value=measureDiv.innerText;
    measureDiv.innerText='';
    measureDiv.appendChild(measureInput);
    const qtyInput=document.createElement('input');
    const qtyAtr = document.createAttribute("name");      
    qtyAtr.value = "quantity-per-unit";                           
    qtyInput.setAttributeNode(qtyAtr);
    qtyInput.classList.add('qty-per-unit-input');
    qtyInput.classList.add('input');
    qtyInput.placeholder='Quantity Per Unit';
    qtyInput.value=qtyDiv.innerText;
    qtyDiv.innerText='';
    qtyDiv.appendChild(qtyInput);
    const priceInput=document.createElement('input');
    const priceAtr = document.createAttribute("name");      
    priceAtr.value = "unit-price";                           
    priceInput.setAttributeNode(priceAtr);
    priceInput.classList.add('unit-price-input');
    priceInput.classList.add('input');
    priceInput.placeholder='Unit Price';
    priceInput.value=priceDiv.innerText;
    priceDiv.innerText='';
    priceDiv.appendChild(priceInput);
    const discontinuedSelect=document.createElement('select');
    discontinuedSelect.classList.add('discontinued-select');
    discontinuedSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    discontinuedSelect.appendChild(trueOption);
    discontinuedSelect.appendChild(falseOption);
    if(discontinuedDiv.innerText!=='')
    {
        discontinuedSelect.value=discontinuedDiv.innerText;
        discontinuedDiv.innerText='';
    }else{
        discontinuedSelect.options.selectedIndex=0;
    }
    discontinuedDiv.appendChild(discontinuedSelect);
    const createdInput=document.createElement('input');
    const createdAtr = document.createAttribute("name");      
    createdAtr.value = "created-at";                           
    createdInput.setAttributeNode(createdAtr);
    createdInput.classList.add('created-at-input');
    createdInput.classList.add('input');
    createdInput.value=createdDiv.innerText;
    createdDiv.innerText='';
    createdDiv.appendChild(createdInput);
    const modifiedInput=document.createElement('input');
    const modifiedAtr = document.createAttribute("name");      
    modifiedAtr.value = "modified-at";                           
    modifiedInput.setAttributeNode(modifiedAtr);
    modifiedInput.classList.add('modified-at-input');
    modifiedInput.classList.add('input');
    modifiedInput.value=date;
    modifiedDiv.innerText='';
    modifiedDiv.appendChild(modifiedInput);
    const inputList=card.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const saveProductCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.remove('card-form');
    const idDiv=card.querySelector('.id-val');
    const nameDiv=card.querySelector('.name-val');
    const barcodeDiv=card.querySelector('.barcode-val');
    const familyDiv=card.querySelector('.family-val');
    const measureDiv=card.querySelector('.measure-val');
    const qtyDiv=card.querySelector('.quantity-val');
    const priceDiv=card.querySelector('.price-val');
    const discontinuedDiv=card.querySelector('.discontinued-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__save-button', 'card__edit-button');
    editButton.removeEventListener('click', validateForm);
    editButton.addEventListener('click', editProductCard);
    const idInput=card.querySelector('.id-input');
    const nameInput=card.querySelector('.product-name-input');
    const barcodeInput=card.querySelector('.barcode-input');
    const familySelect=card.querySelector('.family-select');
    const measureInput=card.querySelector('.unit-measure-input');
    const qtyInput=card.querySelector('.qty-per-unit-input');
    const priceInput=card.querySelector('.unit-price-input');
    const discontinuedSelect=card.querySelector('.discontinued-select');
    const createdInput=card.querySelector('.created-at-input');
    const modifiedInput=card.querySelector('.modified-at-input');
    const product={};
    product.id=idInput.value;
    product.productName=nameInput.value;
    product.barcode=barcodeInput.value;
    product.family=familySelect.value;
    product.unitMeasure=measureInput.value;
    product.qtyPerUnit=qtyInput.value;
    product.unitPrice=priceInput.value;
    product.discontinued=discontinuedSelect.value;
    product.dateCreated=createdInput.value;
    product.dateModified=modifiedInput.value;
    idDiv.innerText=product.id;
    nameDiv.innerText=product.productName;
    barcodeDiv.innerText=product.barcode;
    familyDiv.innerText=product.family;
    measureDiv.innerText=product.unitMeasure;
    qtyDiv.innerText=product.qtyPerUnit;
    priceDiv.innerText=product.unitPrice;
    discontinuedDiv.innerText=product.discontinued;
    createdDiv.innerText=product.dateCreated;
    modifiedDiv.innerText=product.dateModified;
}

//  fill table with data
fillProducts(products);

//  add view-mode event listener
const tableModeButton=document.querySelector('.view-options__table');
tableModeButton.addEventListener('click', ()=>{
    if(!viewMode)
    {
        viewMode=true;
        fillProducts(products);
    }
})
const cardModeButton=document.querySelector('.view-options__card');
cardModeButton.addEventListener('click', ()=>{
    if(viewMode)
    {
        viewMode=false;
        fillProducts(products);
    }
})

//  fill placeholders with current date
const createdInput=document.querySelector('.created-at-input');
const modifiedInput=document.querySelector('.modified-at-input');
const today = new Date();
const date = today.getDate()+'-'+(today.getMonth()+1)+'-'+today.getFullYear();
createdInput.value=date;
modifiedInput.value=date;

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
        submitProduct();
        if(newItem){
            const form=document.querySelector('form');
            form.reset();
            addButton.click();
            newItem=false;
        }else{
            formRow.remove();
        }
    }else{
        saveProductCard(e);
    }
}

//  add product event listener
const addButton=document.querySelector('.add-product-button');
const form=document.querySelector('.table__form');
addButton.addEventListener('click', function(){
    if(viewMode)
    {
        form.classList.toggle('hidden');
        this.classList.toggle('hide-button');
        this.classList.toggle('add-product-button');
        const inputList=form.querySelectorAll('.input');
        inputList.forEach(element => {
            element.addEventListener('blur', validateInput);
        });
        const familySelect=document.querySelector('.family-select');
        families.forEach(family => {
            const option=document.createElement('option');
            option.innerText=family.name;
            familySelect.appendChild(option);
        });
        newItem=true;
    }else{
        const emptyProduct={ };
        addProductToCard(emptyProduct);
        const lastCard=document.querySelector('.cards-container').lastChild;
        const editButton=lastCard.querySelector('.card__button-1');
        editButton.click();
    }
});

//  submit new product form event listener
const submitButton=document.querySelector('.submit-button');
submitButton.addEventListener('click', validateForm);