const products=[
    {
        id:'001',
        productName:'apple',
        barcode: '12345',
        family: 'fruit',
        unitMeasure: 'kg',
        qtyPerUnit: '1',
        unitPrice: '1.5',
        discontinued: false,
        dateCreated: '27-09-2020',
        dateModified: '27-09-2020'
    },
    {
        id:'002',
        productName:'pear',
        barcode: '23456',
        family: 'fruit',
        unitMeasure: 'kg',
        qtyPerUnit: '1',
        unitPrice: '1.9',
        discontinued: false,
        dateCreated: '27-09-2020',
        dateModified: '27-09-2020'
    },
    {
        id:'003',
        productName:'cola',
        barcode: '34567',
        family: 'drink',
        unitMeasure: 'liter',
        qtyPerUnit: '1',
        unitPrice: '2.2',
        discontinued: false,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    }
]

const families=[
    {
        id: '001',
        name: 'fruit'
    },
    {
        id: '002',
        name: 'drink'
    }
]

const stores=[
    {
        id: '001',
        name: 'Lisboa Store',
        address: 'Rua Dr. Eduardo Neves, 3, 1050-077 Lisboa',
        active: true,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '002',
        name: 'Porto Store',
        address: 'Rua Oliveira Monteiro, 168, 4050–438 Porto',
        active: true,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    }
]

const stocks=[
    {
        id: '001',
        product: 'apple',
        store: 'Lisboa Store',
        quantity: '25',
        quantityBase: '0',
        saleUnit: true,
        quantitySaleUnit: '5',
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '002',
        product: 'pear',
        store: 'Lisboa Store',
        quantity: '19',
        quantityBase: '0',
        saleUnit: true,
        quantitySaleUnit: '4',
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '003',
        product: 'cola',
        store: 'Porto Store',
        quantity: '30',
        quantityBase: '0',
        saleUnit: true,
        quantitySaleUnit: '10',
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    }
]

const pos=[
    {
        id: '001',
        store: 'Lisboa Store',
        address: 'Rua Dr. Eduardo Neves, 3, 1050-077 Lisboa',
    },
    {
        id: '002',
        store: 'Porto Store',
        address: 'Rua Oliveira Monteiro, 168, 4050–438 Porto',
    }
]

const sales=[
    {
        id: '001',
        saleDocNum: '12345',
        store: 'Lisboa Store',
        pos: '001',
        user: 'DHouston20',
        customer: 'Daisie Houston',
        payed: true,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '002',
        saleDocNum: '67890',
        store: 'Lisboa Store',
        pos: '001',
        user: 'maisonL',
        customer: 'Maison Lowry',
        payed: true,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '003',
        saleDocNum: '54321',
        store: 'Porto Store',
        pos: '002',
        user: 'j.hoover',
        customer: 'Joseph Hoover',
        payed: false,
        dateCreated: '28-09-2020',
        dateModified: '28-09-2020'
    },
    {
        id: '004',
        saleDocNum: '98765',
        store: 'Porto Store',
        pos: '002',
        user: 'Baxter19',
        customer: 'Allan Baxter',
        payed: false,
        dateCreated: '29-09-2020',
        dateModified: '29-09-2020'
    }
]

const users=[
    {
        id: '001',
        name: 'DHouston20',
        number: '12345',
        password: 'pass1234'
    },
    {
        id: '002',
        name: 'maisonL',
        number: '67890',
        password: '1234pass'
    },
    {
        id: '003',
        name: 'j.hoover',
        number: '54321',
        password: 'password1'
    },
    {
        id: '004',
        name: 'Baxter19',
        number: '98765',
        password: 'longpass'
    }
]

export {products, families, stores, stocks, pos, sales, users};